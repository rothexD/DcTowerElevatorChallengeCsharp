using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using DcTowerElevatorChallengeCsharp.Services;
using ImplementDcElevatorChallenge.ImplementSheduler;
using System.Threading;
using DcTowerElevatorChallengeCsharp.Enum;

namespace ImplementDcElevatorChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ISheduler sheduler = new TakeClosestSheduler();

            sheduler.AddRequest(new RequestElevator(0, 45, Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 0, Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 35, Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 25, Directions.up));
            sheduler.AddRequest(new RequestElevator(0, 22, Directions.up));
            sheduler.AddRequest(new RequestElevator(40, 30, Directions.down));
            sheduler.AddRequest(new RequestElevator(30, 20, Directions.down));
            sheduler.AddRequest(new RequestElevator(40, 0, Directions.down));

            IRequestElevator a = RequestElevator.Builder().SetCurrent_Floor(1).SetDestination_floor(2).SetDirections(Directions.up);

            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            sheduler.AddRequest(RequestElevator.GenerateRandomRequest());

            int counter = 0;
            while (true)
            {
                Thread.Sleep(1000);
                counter++;
                if (counter % 13 == 0)
                {
                    sheduler.AddRequest(RequestElevator.GenerateRandomRequest());
                }
                sheduler.Status();
            }

        }
    }
}
