using FluentValidation;

namespace DcTowerElevatorChallengeCsharp.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public BaseValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}
