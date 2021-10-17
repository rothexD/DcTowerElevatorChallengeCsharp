﻿using System;
using System.Collections.Generic;
using System.Text;
using DcTowerElevatorChallengeCsharp.CustomExceptions;
using DcTowerElevatorChallengeCsharp.Data_Objects;
using FluentValidation;

namespace DcTowerElevatorChallengeCsharp.Validators
{
    public class RequestElevatorValidator : BaseValidator<IRequestElevator>
    {
        public RequestElevatorValidator()
        {
            RuleFor(x => x.Current_Floor)
                .NotNull().WithMessage("{parametername} was null");
            RuleFor(x => x.Destination_Floor)
                .NotNull().WithMessage("{parametername} was null")
                .NotEqual(x => x.Current_Floor).WithMessage("CurrentFloor is equal to DestinationFloor");
            RuleFor(x => x.Directions)
                .NotNull().WithMessage("{parametername} was null");
        }
    }
}