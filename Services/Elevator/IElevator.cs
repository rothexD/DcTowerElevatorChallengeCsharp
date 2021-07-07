using DcTowerElevatorChallengeCsharp.Data_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DcTowerElevatorChallengeCsharp.Services
{
    public interface IElevator
    {
        public bool Transport(RequestElevator requestedTransport);
    }
}
