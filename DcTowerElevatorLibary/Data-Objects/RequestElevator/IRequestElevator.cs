using DcTowerElevatorChallengeCsharp.Enum;

namespace DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator
{
    public interface IRequestElevator
    {
        public int CurrentFloor { get; }
        public int DestinationFloor { get; }
        public Directions Directions { get; }
    }
}
