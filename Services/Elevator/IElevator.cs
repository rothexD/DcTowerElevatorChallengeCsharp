using DcTowerElevatorChallengeCsharp.Data_Objects;

namespace DcTowerElevatorChallengeCsharp.Services
{
    public interface IElevator
    {
        public bool Transport(RequestElevator requestedTransport);
        public int CurrentElevatorLocation { get; }
        public string ElevatorName { get; }
    }
}
