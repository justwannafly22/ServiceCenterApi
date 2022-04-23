using FluentValidation;
using ProductApi.Boundary.RequestModels;
using System;

namespace ProductApi.Infrastructure.Validators
{
    public class DeleteProductRequestModelValidator : AbstractValidator<DeleteProductRequestModel>
    {
        public DeleteProductRequestModelValidator()
        {
            RuleFor(r => r.Id)
                .NotEqual(new Guid());
        }
    }
}
