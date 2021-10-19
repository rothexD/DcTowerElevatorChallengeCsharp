using FluentValidation;

namespace DcTowerElevatorChallengeCsharp.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected BaseValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}
