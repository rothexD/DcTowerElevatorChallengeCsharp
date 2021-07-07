using System;
using System.Collections.Generic;
using System.Text;
using DcTowerElevatorChallengeCsharp.Data_Objects;
using System.Collections.Concurrent;
using System.Threading;

namespace DcTowerElevatorChallengeCsharp.Services
{
    class Sheduler : ISheduler
    {
        // stores all recieved requests
        private BlockingCollection<RequestElevator> RequestQueue { get; } = new BlockingCollection<RequestElevator>();

        //stores all avaiable elevators
        private BlockingCollection<IElevator> ElevatorQueue { get; } = new BlockingCollection<IElevator>();


        public bool AddRequest(RequestElevator request)
        {
            // Check if valid request here

            RequestQueue.Add(request);
            return true;
        }
        public void Status()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Requested Status:"+ Environment.NewLine + "Requests left: " + RequestQueue.Count + ", Elevators left: " + ElevatorQueue.Count + Environment.NewLine + Environment.NewLine) ;
            Console.WriteLine();
        }

        public Sheduler()
        {
            // Initial elevator setup
            ElevatorQueue.Add(new Elevator("1"));
            ElevatorQueue.Add(new Elevator("2"));
            ElevatorQueue.Add(new Elevator("3"));
            ElevatorQueue.Add(new Elevator("4"));
            ElevatorQueue.Add(new Elevator("5"));
            ElevatorQueue.Add(new Elevator("6"));
            ElevatorQueue.Add(new Elevator("7"));
            SheduleTransportation();
        }
        private void SheduleTransportation()
        {
            Thread sheduleThread = new Thread(() => {
                while (true)
                {
                    RequestElevator request = RequestQueue.Take();
                    IElevator elevator = ElevatorQueue.Take();
                    StartElevatorJurney(request, elevator);
                }
            });
            sheduleThread.Start();
        }
        private void StartElevatorJurney(RequestElevator request, IElevator elevator)
        {
            Thread elevatorThread = new Thread(() => { 
                // call elevator transport method and upon finish enque itself again
                elevator.Transport(request);
                ElevatorQueue.Add(elevator);
            });
            elevatorThread.Start();
        }
    }
}
