using DcTowerElevatorChallengeCsharp.Services;
using System;
using DcTowerElevatorChallengeCsharp.Data_Objects;

namespace DcTowerElevatorChallengeCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISheduler sheduler = new Sheduler();

            sheduler.AddRequest(new RequestElevator(0,55,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0,45,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0,35,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0,25,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0,22,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(40,30,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(30,20,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(40,0,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(10,34,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(5,22,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(2,21,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(50,34,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(22,0,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(35,0,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(35,0,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(12,0,Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(20,25,Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0,35,Enum.Directions.up));
        }
    }
}
