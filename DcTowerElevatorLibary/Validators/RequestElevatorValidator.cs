using DcTowerElevatorChallengeCsharp.Data_Objects.RequestElevator;
using FluentValidation;

namespace DcTowerElevatorChallengeCsharp.Validators
{
    public class RequestElevatorValidator : BaseValidator<IRequestElevator>
    {
        public RequestElevatorValidator()
        {
            RuleFor(x => x.CurrentFloor)
                .NotNull().WithMessage("{PropertyName} was null");
            RuleFor(x => x.DestinationFloor)
                .NotNull().WithMessage("{PropertyName} was null")
                .NotEqual(x => x.CurrentFloor).WithMessage("CurrentFloor is equal to DestinationFloor");
            RuleFor(x => x.Directions)
                .NotNull().WithMessage("{PropertyName} was null");
            When(x => x.Directions.ToString().ToUpper() == "UP", () =>
            {
                RuleFor(x => x.CurrentFloor).LessThan(x => x.DestinationFloor).WithMessage("CurrentFloor is larger than DestinationFloor but up was sent");
            });
            When(x => x.Directions.ToString().ToUpper() == "down", () =>
            {
                RuleFor(x => x.CurrentFloor).GreaterThan(x => x.DestinationFloor).WithMessage("CurrentFloor is larger than DestinationFloor but down was sent");
            });
        }
    }
}
