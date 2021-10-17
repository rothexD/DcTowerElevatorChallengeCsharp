using DcTowerElevatorChallengeCsharp.Data_Objects;
using System.Collections.Concurrent;

namespace DcTowerElevatorChallengeCsharp.Services
{
    class TakeNextAvaiableSheduler_FIFO : ASheduler
    {
        private BlockingCollection<IElevator> ElevatorQueue { get; } = new BlockingCollection<IElevator>();

        public TakeNextAvaiableSheduler_FIFO()
        {
            ElevatorQueue.Add(new Elevator("1"));
            ElevatorQueue.Add(new Elevator("2"));
            ElevatorQueue.Add(new Elevator("3"));
            ElevatorQueue.Add(new Elevator("4"));
            ElevatorQueue.Add(new Elevator("5"));
            ElevatorQueue.Add(new Elevator("6"));
            ElevatorQueue.Add(new Elevator("7"));
        }

        protected override IElevator ChooseElevator(IRequestElevator request)
        {
            return ElevatorQueue.Take();
        }
        protected override bool EnqueElevator(IElevator elevator)
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
