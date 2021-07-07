using System;
using System.Collections.Generic;
using System.Text;
using DcTowerElevatorChallengeCsharp.Enum;

namespace DcTowerElevatorChallengeCsharp.Data_Objects
{

    public class RequestElevator
    {
        public int Current_floor { get; private set; }
        public int Destination_floor { get; private set; }
        public Directions Direction { get; private set; }

        public RequestElevator(int current_floor, int destination_floor,Directions direction)
        {
            Current_floor = current_floor;
            Destination_floor = destination_floor;
            Direction = direction;
        }
    }
}
