using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using DcTowerElevatorChallengeCsharp.Services;
using ImplementDcElevatorChallenge.ImplementScheduler;
using System.Threading;
using DcTowerElevatorChallengeCsharp.Enum;
using DcTowerElevatorChallengeCsharp.Services.Elevator;
using DcTowerElevatorChallengeCsharp.Services.Scheduler;

namespace ImplementDcElevatorChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            IScheduler scheduler = new TakeClosestScheduler();

           

            scheduler.EnqueueElevator(new Elevator("1"));
            scheduler.EnqueueElevator(new Elevator("2"));
            scheduler.EnqueueElevator(new Elevator("3"));
            scheduler.EnqueueElevator(new Elevator("4"));
            scheduler.EnqueueElevator(new Elevator("5"));
            scheduler.EnqueueElevator(new Elevator("6"));
            scheduler.EnqueueElevator(new Elevator("7"));
            
            
            IRequestElevator a = RequestElevator.Builder().SetCurrent_Floor(2).SetDestination_floor(1).SetDirections(Directions.Up);

            scheduler.AddRequest(a);
            
            scheduler.AddRequest(new RequestElevator(0, 0, Directions.Up));
            scheduler.AddRequest(new RequestElevator(0, 0, Directions.Up));
            scheduler.AddRequest(new RequestElevator(0, 0, Directions.Up));
            scheduler.AddRequest(new RequestElevator(0, 0, Directions.Up));
            scheduler.AddRequest(new RequestElevator(0, 0, Directions.Up));
            scheduler.AddRequest(new RequestElevator(40, 0, Directions.Down));
            scheduler.AddRequest(new RequestElevator(30, 0, Directions.Down));
            scheduler.AddRequest(new RequestElevator(40, 0, Directions.Down));

            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
            scheduler.AddRequest(RequestElevator.GenerateRandomRequest());

            int counter = 0;
            while (true)
            {
                Thread.Sleep(1000);
                counter++;
                if (counter % 13 == 0)
                {
                    scheduler.AddRequest(RequestElevator.GenerateRandomRequest());
                }
                scheduler.Status();
            }
        }
    }
}
