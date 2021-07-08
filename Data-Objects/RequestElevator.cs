using DcTowerElevatorChallengeCsharp.Enum;
using System;
namespace DcTowerElevatorChallengeCsharp.Data_Objects
{

    public class RequestElevator
    {
        public static RequestElevator GenerateRequest()
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
        public int Current_floor { get; private set; }
        public int Destination_floor { get; private set; }
        public Directions Direction { get; private set; }

        public RequestElevator(int current_floor, int destination_floor, Directions direction)
        {
            Current_floor = current_floor;
            Destination_floor = destination_floor;
            Direction = direction;
        }
    }
}
