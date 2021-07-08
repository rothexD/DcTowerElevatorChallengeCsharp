using DcTowerElevatorChallengeCsharp.Data_Objects;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace DcTowerElevatorChallengeCsharp.Services
{
    abstract class Sheduler : ISheduler
    {
        // stores all recieved requests
        private BlockingCollection<RequestElevator> RequestQueue { get; } = new BlockingCollection<RequestElevator>();

        //stores all avaiable elevators



        public bool AddRequest(RequestElevator request)
        {
            // Check if valid request here

            RequestQueue.Add(request);
            return true;
        }
        public void Status()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Requested Status:" + Environment.NewLine + "Requests left: " + RequestQueue.Count + ", Elevators Status: " + ElevatorStatus() + Environment.NewLine + Environment.NewLine);
            Console.WriteLine();
        }


        public Sheduler()
        {
            // Initial elevator setup

            SheduleTransportation();
        }
        protected abstract IElevator ChooseElevator(RequestElevator request);
        protected abstract bool EnqueElevator(IElevator elevator);
        protected abstract string ElevatorStatus();

        private void SheduleTransportation()
        {
            Thread sheduleThread = new Thread(() =>
            {
                while (true)
                {
                    RequestElevator request = RequestQueue.Take();
                    IElevator elevator = ChooseElevator(request);
                    StartElevatorJurney(request, elevator);
                }
            });
            sheduleThread.Start();
        }
        private void StartElevatorJurney(RequestElevator request, IElevator elevator)
        {
            Thread elevatorThread = new Thread(() =>
            {
                // call elevator transport method and upon finish enque itself again
                elevator.Transport(request);
                EnqueElevator(elevator);


            });
            elevatorThread.Start();
        }
    }
}
