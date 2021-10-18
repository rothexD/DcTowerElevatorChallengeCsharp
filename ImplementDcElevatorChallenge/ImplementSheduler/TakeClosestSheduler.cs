using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using DcTowerElevatorChallengeCsharp.Services;

namespace ImplementDcElevatorChallenge.ImplementSheduler
{
    class TakeClosestSheduler : ASheduler
    {
        private ConcurrentDictionary<string, IElevator> ElevatorQueue { get; } = new ConcurrentDictionary<string, IElevator>();
        private ManualResetEvent elevatorJustEnqued = new ManualResetEvent(false);
        public TakeClosestSheduler()
        {
            EnqueElevator(new Elevator("1"));
            EnqueElevator(new Elevator("2"));
            EnqueElevator(new Elevator("3"));
            EnqueElevator(new Elevator("4"));
            EnqueElevator(new Elevator("5"));
            EnqueElevator(new Elevator("6"));
            EnqueElevator(new Elevator("7"));
        }

        protected override IElevator ChooseElevator(IRequestElevator request)
        {
            //wait until the elevator signal was set atleast once
            elevatorJustEnqued.WaitOne();       

            lock (ElevatorQueue)
            {
                string closestElevatorKey = FindClosestElevatorKey(request);
                Console.WriteLine("tried remove Elevator: " + closestElevatorKey + " with count ElevatorCount " + ElevatorStatus());
                ElevatorQueue.TryRemove(closestElevatorKey, out IElevator chosenElevator);

                if (ElevatorQueue.Count == 0)
                {
                    elevatorJustEnqued.Reset();
                }
                return chosenElevator;
            }
        }

        private string FindClosestElevatorKey(IRequestElevator request)
        {
            string closestElevatorKey = "";
            int closestDistance = int.MaxValue;

            ElevatorQueue.ToList().ForEach(elevator =>
            {
                int distance = Math.Abs(elevator.Value.CurrentElevatorLocation - request.Current_Floor);
                if (distance < closestDistance)
                {
                    closestElevatorKey = elevator.Key;
                }
            });
            return closestElevatorKey;
        }

        protected override bool EnqueElevator(IElevator elevator)
        {
            lock (ElevatorQueue)
            {
                ElevatorQueue.TryAdd(elevator.ElevatorName, elevator);
                elevatorJustEnqued.Set();
                return true;
            }
        }

        protected override string ElevatorStatus()
        {
            return ElevatorQueue.Count.ToString();
        }
    }
}
