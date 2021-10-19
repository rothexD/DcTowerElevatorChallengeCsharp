using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator.RequestElevatorFluentApiInterfaces;
using DcTowerElevatorChallengeCsharp.Enum;
using System;
namespace DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator
{

    public class RequestElevator : IRequestElevator, ISetCurrent_Floor, ISetDestination_Floor, ISetDirections
    {
        public int CurrentFloor { get; private set; }
        public int DestinationFloor { get; private set; }
        public Directions Directions { get; private set; }

        public RequestElevator(int currentFloor, int destinationFloor, Directions direction)
        {
            CurrentFloor = currentFloor;
            DestinationFloor = destinationFloor;
            Directions = direction;
        }
        private RequestElevator() { }
        public static IRequestElevator GenerateRandomRequest()
        {
            Random dice = new Random(Guid.NewGuid().GetHashCode());
            int from = dice.Next(0, 56);
            int too = dice.Next(0, 56);
            if (from < too)
            {
                return new RequestElevator(from, too, Directions.Up);
            }
            else
            {
                return new RequestElevator(from, too, Directions.Down);
            }
        }
        
        public static ISetCurrent_Floor Builder()
        {
            return new RequestElevator();
        }
        public ISetDestination_Floor SetCurrent_Floor(int currentFloor)
        {
            this.CurrentFloor = currentFloor;
            return this;
        }
        public ISetDirections SetDestination_floor(int destinationFloor)
        {
            this.DestinationFloor = destinationFloor;
            return this;
        }
        public IRequestElevator SetDirections(Directions directions)
        {
            this.Directions = directions;
            return this;
        }
    }
}
