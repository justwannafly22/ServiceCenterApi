using FluentValidation;
using ProductApi.Boundary.RequestModels;
using System;

namespace ProductApi.Infrastructure.Validators
{
    public class GetByIdProductRequestModelValidator : AbstractValidator<GetByIdProductRequestModel>
    {
        public GetByIdProductRequestModelValidator()
        {
            RuleFor(r => r.Id)
                .NotEqual(new Guid());
        }
    }
}
