using DcTowerElevatorChallengeCsharp.Data_Objects;

namespace DcTowerElevatorChallengeCsharp.Services
{
    public interface ISheduler
    {
        public bool AddRequest(RequestElevator request);
        public void Status();
    }
}
