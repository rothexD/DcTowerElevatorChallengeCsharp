using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using DcTowerElevatorChallengeCsharp.Services;
using DcTowerElevatorChallengeCsharp.Services.Elevator;
using DcTowerElevatorChallengeCsharp.Services.Scheduler;

namespace ImplementDcElevatorChallenge.ImplementScheduler
{
    class TakeClosestScheduler : AScheduler
    {
        private ConcurrentDictionary<string, IElevator> ElevatorQueue { get; } 
        
        private readonly ManualResetEvent _elevatorJustEnqueued = new ManualResetEvent(false);
        public TakeClosestScheduler(ConcurrentDictionary<string, IElevator> elevatorQueue = null,BlockingCollection<IRequestElevator> requestCollection = null)
            : base(requestCollection)
        {
            ElevatorQueue = elevatorQueue ?? new ConcurrentDictionary<string, IElevator>();
        }

        protected override IElevator ChooseElevator(IRequestElevator request)
        {
            //wait until the elevator signal was set at least once
            _elevatorJustEnqueued.WaitOne();

                lock (ElevatorQueue)
            {
                string closestElevatorKey = FindClosestElevatorKey(request);
                Console.WriteLine("tried remove Elevator: " + closestElevatorKey + " with count ElevatorCount " + ElevatorStatus());
                ElevatorQueue.TryRemove(closestElevatorKey, out IElevator chosenElevator);

                if (ElevatorQueue.Count == 0)
                {
                    _elevatorJustEnqueued.Reset();
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
                int distance = Math.Abs(elevator.Value.CurrentElevatorLocation - request.CurrentFloor);
                if (distance < closestDistance)
                {
                    closestElevatorKey = elevator.Key;
                }
            });
            return closestElevatorKey;
        }

        public override bool EnqueueElevator(IElevator elevator)
        {
            lock (ElevatorQueue)
            {
                ElevatorQueue.TryAdd(elevator.ElevatorName, elevator);
                _elevatorJustEnqueued.Set();
                return true;
            }
        }

        protected override string ElevatorStatus()
        {
            return ElevatorQueue.Count.ToString();
        }
    }
}
