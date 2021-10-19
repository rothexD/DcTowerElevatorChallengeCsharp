using DcTowerElevatorChallengeCsharp.Data_Objects;
using System.Collections.Concurrent;
using DcTowerElevatorChallengeCsharp.Services;
using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using DcTowerElevatorChallengeCsharp.Services.Elevator;
using DcTowerElevatorChallengeCsharp.Services.Scheduler;

namespace ImplementDcElevatorChallenge.ImplementScheduler
{
    class TakeNextAvailableSchedulerFifo : AScheduler
    {
        private BlockingCollection<IElevator> ElevatorQueue { get; }

        public TakeNextAvailableSchedulerFifo(BlockingCollection<IElevator> elevatorQueue = null,BlockingCollection<IRequestElevator> requestCollection = null)
            : base(requestCollection)
        {
            ElevatorQueue = elevatorQueue ?? new BlockingCollection<IElevator>();;
        }

        protected override IElevator ChooseElevator(IRequestElevator request)
        {
            return ElevatorQueue.Take();
        }
        public override bool EnqueueElevator(IElevator elevator)
        {
            ElevatorQueue.Add(elevator);
            return true;
        }

        protected override string ElevatorStatus()
        {
            return ElevatorQueue.Count.ToString();
        }
    }
}
