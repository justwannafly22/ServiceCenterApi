using FluentValidation;
using MasterApi.Boundary.Master.RequestModels;

namespace MasterApi.Infrastructure.Validators
{
    public class CreateMasterRequestModelValidator : AbstractValidator<CreateMasterRequestModel>
    {
        public CreateMasterRequestModelValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");

            RuleFor(r => r.Surname)
                .NotNull().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");

            RuleFor(r => r.Age)
                .NotNull().GreaterThanOrEqualTo(18).LessThan(150);

            RuleFor(r => r.ContactNumber)
                .NotNull().WithMessage("{PropertyName} is a required field.");
        }
    }
}
