﻿using DcTowerElevatorChallengeCsharp.Data_Objects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DcTowerElevatorChallengeCsharp.Services

{
    class TakeClosestSheduler : Sheduler
    {
        private ConcurrentDictionary<string, IElevator> ElevatorQueue { get; } = new ConcurrentDictionary<string, IElevator>();
        private ManualResetEvent elevatorJustEnqued = new ManualResetEvent(false);
        public TakeClosestSheduler()
        {
            EnqueElevator(new Elevator("1"));
            EnqueElevator(new Elevator("2"));
            EnqueElevator(new Elevator("3"));
            EnqueElevator(new Elevator("4"));
            EnqueElevator(new Elevator("5"));
            EnqueElevator(new Elevator("6"));
            EnqueElevator(new Elevator("7"));
        }

        protected override IElevator ChooseElevator(RequestElevator request)
        {

            elevatorJustEnqued.WaitOne();

            string closestElevatorKey = FindClosestElevatorKey(request);

            lock (ElevatorQueue)
            {
                Console.WriteLine("tried remove: " + closestElevatorKey +" with count "+ ElevatorStatus());
                ElevatorQueue.TryRemove(closestElevatorKey, out IElevator chosenElevator);

                    if (ElevatorQueue.Count == 0)
                    {
                        elevatorJustEnqued.Reset();
                    }
                return chosenElevator;
            }
        }

        private string FindClosestElevatorKey(RequestElevator request)
        {
            string closestElevatorKey = "";
            int closestDistance = int.MaxValue;

            foreach (var elevator in ElevatorQueue.ToList())
            {
                int distance = Math.Abs(elevator.Value.CurrentElevatorLocation - request.Current_floor);
                if (distance < closestDistance)
                {
                    closestElevatorKey = elevator.Key;
                }
            }
            return closestElevatorKey;
        }

        protected override bool EnqueElevator(IElevator elevator)
        {
            lock (ElevatorQueue)
            {
                ElevatorQueue.TryAdd(elevator.ElevatorName, elevator);
                elevatorJustEnqued.Set();
                return true;
            }
        }

        protected override string ElevatorStatus()
        {
            return ElevatorQueue.Count.ToString();
        }
    }
}