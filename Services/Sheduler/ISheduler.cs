using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;

namespace DcTowerElevatorChallengeCsharp.Services
{
    public interface ISheduler
    {
        public bool AddRequest(IRequestElevator request);
        public void Status();
    }
}
