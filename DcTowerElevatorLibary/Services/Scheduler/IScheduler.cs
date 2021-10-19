using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using DcTowerElevatorChallengeCsharp.Services.Elevator;

namespace DcTowerElevatorChallengeCsharp.Services.Scheduler
{
    public interface IScheduler
    {
        public bool AddRequest(IRequestElevator request);
        public void Status();
        public bool EnqueueElevator(IElevator elevator);
    }
}
