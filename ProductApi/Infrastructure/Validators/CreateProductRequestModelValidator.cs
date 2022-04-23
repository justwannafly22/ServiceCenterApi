using FluentValidation;
using ProductApi.Boundary.RequestModels;

namespace ProductApi.Infrastructure.Validators
{
    public class CreateProductRequestModelValidator : AbstractValidator<CreateProductRequestModel>
    {
        public CreateProductRequestModelValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");

            RuleFor(r => r.Price)
                .NotNull()
                .GreaterThan(0).LessThan(double.MaxValue)
                .WithMessage("{PropertyName} is required and it can`t be lower than 0 or greater than 150.");
            
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");
        }
    }
}
