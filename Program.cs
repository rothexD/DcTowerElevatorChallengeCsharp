using DcTowerElevatorChallengeCsharp.Data_Objects;
using DcTowerElevatorChallengeCsharp.Services;
using System.Threading;
namespace DcTowerElevatorChallengeCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISheduler sheduler = new TakeClosestSheduler();

            sheduler.AddRequest(new RequestElevator(0, 55, Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 45, Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 35, Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 25, Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 22, Enum.Directions.up));
            sheduler.AddRequest(new RequestElevator(40, 30, Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(30, 20, Enum.Directions.down));
            sheduler.AddRequest(new RequestElevator(40, 0, Enum.Directions.down));


            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());
            sheduler.AddRequest(RequestElevator.GenerateRequest());

            int counter = 0;
            while (true)
            {
                Thread.Sleep(1000);
                counter++;
                if (counter % 13 == 0)
                {
                    sheduler.AddRequest(RequestElevator.GenerateRequest());
                }
                sheduler.Status();
            }

        }
    }
}
