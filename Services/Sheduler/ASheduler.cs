using DcTowerElevatorChallengeCsharp.Data_Objects;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace DcTowerElevatorChallengeCsharp.Services
{
    abstract class ASheduler : ISheduler
    {
        // stores all recieved requests
        private BlockingCollection<IRequestElevator> RequestQueue { get; } = new BlockingCollection<IRequestElevator>();


        public bool AddRequest(IRequestElevator request)
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


        public ASheduler()
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
                    IRequestElevator request = RequestQueue.Take();
                    IElevator elevator = ChooseElevator(request);
                    StartElevatorJurney(request, elevator);
                }
            });
            sheduleThread.Start();
        }
        private void StartElevatorJurney(IRequestElevator request, IElevator elevator)
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
