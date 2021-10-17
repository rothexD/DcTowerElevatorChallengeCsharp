using DcTowerElevatorChallengeCsharp.Enum;

namespace DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevatorFluentApiInterfaces
{
    public interface ISetDirections
    {
        public IRequestElevator SetDirections(Directions directions);
    }
}
