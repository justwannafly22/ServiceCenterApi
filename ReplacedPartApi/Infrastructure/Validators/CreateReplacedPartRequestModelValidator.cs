using FluentValidation;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;

namespace ReplacedPartApi.Infrastructure.Validators.ReplacedPart
{
    public class CreateReplacedPartRequestModelValidator : AbstractValidator<CreateReplacedPartRequestModel>
    {
        public CreateReplacedPartRequestModelValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");

            RuleFor(r => r.Price)
                .NotNull()
                .GreaterThan(0).LessThan(double.MaxValue)
                .WithMessage("{PropertyName} is required and it can`t be lower than 0.");

            RuleFor(r => r.Count)
                .NotNull()
                .GreaterThan(0).LessThan(int.MaxValue)
                .WithMessage("{PropertyName} is required and it can`t be lower than 0.");

            RuleFor(r => r.AdvancedInfo)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 500).WithMessage("Max length for {PropertyName} is 60 characters.");
        }
    }
}
