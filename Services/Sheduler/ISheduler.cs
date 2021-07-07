using System;
using System.Collections.Generic;
using System.Text;
using DcTowerElevatorChallengeCsharp.Data_Objects;

namespace DcTowerElevatorChallengeCsharp.Services
{
    public interface ISheduler
    {
        public bool AddRequest(RequestElevator request);
        public void Status();
    }
}
