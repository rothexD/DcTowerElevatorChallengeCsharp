using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator.RequestElevatorFluentApiInterfaces;
using DcTowerElevatorChallengeCsharp.Enum;
using System;
namespace DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator
{

    public class RequestElevator : IRequestElevator, ISetCurrent_Floor, ISetDestination_Floor, ISetDirections
    {
        public static IRequestElevator GenerateRandomRequest()
        {
            Random dice = new Random(Guid.NewGuid().GetHashCode());
            int from = dice.Next(0, 56);
            int too = dice.Next(0, 56);
            if (from < too)
            {
                return new RequestElevator(from, too, Directions.up);
            }
            else
            {
                return new RequestElevator(from, too, Directions.down);
            }
        }
        public int Current_Floor { get; private set; }
        public int Destination_Floor { get; private set; }
        public Directions Directions { get; private set; }

        public RequestElevator(int current_floor, int destination_floor, Directions direction)
        {
            Current_Floor = current_floor;
            Destination_Floor = destination_floor;
            Directions = direction;
        }
        private RequestElevator()
        {
        }
        public static ISetCurrent_Floor Builder()
        {
            return new RequestElevator();
        }
        public ISetDestination_Floor SetCurrent_Floor(int current_floor)
        {
            this.Current_Floor = current_floor;
            return this;
        }
        public ISetDirections SetDestination_floor(int destination_floor)
        {
            this.Destination_Floor = destination_floor;
            return this;
        }
        public IRequestElevator SetDirections(Directions directions)
        {
            this.Directions = directions;
            return this;
        }
    }
}
