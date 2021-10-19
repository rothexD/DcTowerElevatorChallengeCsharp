using System;
using System.Collections.Concurrent;
using System.Threading;
using DcTowerElevatorChallengeCsharp.CustomExceptions;
using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using DcTowerElevatorChallengeCsharp.Services.Elevator;
using DcTowerElevatorChallengeCsharp.Services.Scheduler;
using DcTowerElevatorChallengeCsharp.Validators;
using FluentValidation.Results;

namespace DcTowerElevatorChallengeCsharp.Services.Scheduler
{
    public abstract class AScheduler : IScheduler
    {
        // stores all received requests
        private BlockingCollection<IRequestElevator> RequestQueue { get; init; }
        protected abstract IElevator ChooseElevator(IRequestElevator request);
        public abstract bool EnqueueElevator(IElevator elevator);
        protected abstract string ElevatorStatus();

        protected AScheduler(BlockingCollection<IRequestElevator> requestCollection = null)
        {
            RequestQueue = requestCollection ?? new BlockingCollection<IRequestElevator>();
            // Initial elevator setup in child class

            ScheduleTransportation();
        }
        public bool AddRequest(IRequestElevator request)
        {
            try
            {
                RequestElevatorValidator validator = new RequestElevatorValidator();
                ValidationResult results = validator.Validate(request);
                if (!results.IsValid)
                {
                    foreach (var e in results.Errors)
                    {
                        Console.WriteLine("Request Rejected: " + e.ErrorMessage);
                    }
                    return false;
                }
            }
            catch (SameFloorException)
            {
                Console.WriteLine("floor was the same");
                return false;
            }
            RequestQueue.Add(request);
            return true;
        }
        public void Status()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Requested Status:" + Environment.NewLine + "Requests left: " + RequestQueue.Count + ", Elevators Status: " + ElevatorStatus() + Environment.NewLine + Environment.NewLine);
            Console.WriteLine();
        }

        private void ScheduleTransportation()
        {
            //start a thread that starts new threads with elevators
            Thread scheduleThread = new Thread(() =>
            {
                //continuously try to start elevator by taking requests and elevators from the queue
                while (true)
                {
                    IRequestElevator request = RequestQueue.Take();
                    IElevator elevator = ChooseElevator(request);
                    StartElevatorJourney(request, elevator);
                }
            });
            scheduleThread.Start();
        }
        private void StartElevatorJourney(IRequestElevator request, IElevator elevator)
        {
            Thread elevatorThread = new Thread(() =>
            {
                elevator.Transport(request);
                EnqueueElevator(elevator);
            });
            
            elevatorThread.Start();
        }
    }
}
