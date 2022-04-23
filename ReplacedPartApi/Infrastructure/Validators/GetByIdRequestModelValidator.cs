using FluentValidation;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;
using System;

namespace ReplacedPartApi.Infrastructure.Validators.ReplacedPart
{
    public class GetByIdReplacedPartRequestModelValidator : AbstractValidator<GetByIdReplacedPartRequestModel>
    {
        public GetByIdReplacedPartRequestModelValidator()
        {
            RuleFor(r => r.Id)
                .NotEqual(new Guid());
        }
    }
}
