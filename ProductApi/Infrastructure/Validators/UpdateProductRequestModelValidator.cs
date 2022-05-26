using FluentValidation;
using ProductApi.Boundary.RequestModels;

namespace ProductApi.Infrastructure.Validators
{
    public class UpdateProductRequestModelValidator : AbstractValidator<UpdateProductRequestModel>
    {
        public UpdateProductRequestModelValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");

            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("{PropertyName} is a required field.")
                .Length(0, 60).WithMessage("Max length for {PropertyName} is 60 characters.");
        }
    }
}
