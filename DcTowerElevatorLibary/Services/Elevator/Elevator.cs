using System;
using System.Threading;
using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;

namespace DcTowerElevatorChallengeCsharp.Services.Elevator
{
    public class Elevator : IElevator
    {
        public int CurrentElevatorLocation { get; private set; } = 0;
        public string ElevatorName { get; }
        private bool _DoorIsOpen = false;

        public Elevator(string elevatorName)
        {
            ElevatorName = elevatorName;
        }

        // simulates a full elvator run
        public bool Transport(IRequestElevator requestedTransport)
        {
            Console.WriteLine("Elevator: " + ElevatorName + " got a request");
            Travel(CurrentElevatorLocation, requestedTransport.CurrentFloor);
            OpenDoor();
            CloseDoor();
            Travel(CurrentElevatorLocation, requestedTransport.DestinationFloor);
            OpenDoor();
            CloseDoor();
            return true;
        }
        private void OpenDoor()
        {
            Thread.Sleep(50);
            _DoorIsOpen = true;
            Console.WriteLine("Elevator: " + ElevatorName + " openend door");
            Thread.Sleep(50);
        }
        private void CloseDoor()
        {
            Thread.Sleep(50);
            _DoorIsOpen = false;
            Console.WriteLine("Elevator: " + ElevatorName + " closed door");
            Thread.Sleep(50);
        }
        private void Travel(int from, int too)
        {
            if (_DoorIsOpen == true)
            {
                throw new Exception("Door was open while trying to travel");
            }
            int distance = Math.Abs(from - too);
            Console.WriteLine("Elevator: " + ElevatorName + " traveling too " + too + " from " + from + " with floor distance " + distance);
            Thread.Sleep(distance * 50);
            CurrentElevatorLocation = too;
        }
    }
}
