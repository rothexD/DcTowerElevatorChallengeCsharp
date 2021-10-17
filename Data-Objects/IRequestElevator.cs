using DcTowerElevatorChallengeCsharp.Enum;

namespace DcTowerElevatorChallengeCsharp.Data_Objects
{
    public interface IRequestElevator
    {
        public int Current_Floor { get; }
        public int Destination_Floor { get; }
        public Directions Directions { get; }
    }
}
