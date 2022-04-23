using FluentValidation;
using RepairApi.Boundary.Repair.RequestModels;

namespace RepairApi.Infrastructure.Validators
{
    public class CreateRepairRequestModelValidator : AbstractValidator<CreateRepairRequestModel>
    {
        public CreateRepairRequestModelValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");

            RuleFor(r => r.Date)
                .NotNull().WithMessage("{PropertyName} is a required field.");

            RuleFor(r => r.AdvancedInfo)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 500).WithMessage("Max length for {PropertyName} is 500 characters.");

            RuleFor(r => r.Status)
                .NotNull().WithMessage("{PropertyName} is a required field.");
        }
    }
}
