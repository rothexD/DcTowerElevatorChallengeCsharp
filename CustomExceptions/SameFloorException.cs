using System;
using System.Collections.Generic;
using System.Text;

namespace DcTowerElevatorChallengeCsharp.CustomExceptions
{
    public class SameFloorException : Exception
    {
        public SameFloorException()
        {
        }

        public SameFloorException(string message)
            : base(message)
        {
        }

        public SameFloorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
