using DcTowerElevatorChallengeCsharp.Data_Objects;

namespace DcTowerElevatorChallengeCsharp.Services
{
    public interface ISheduler
    {
        public bool AddRequest(IRequestElevator request);
        public void Status();
    }
}
