using FluentValidation;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;
using System;


namespace ReplacedPartApi.Infrastructure.Validators.ReplacedPart
{
    public class DeleteReplacedPartRequestModelValidator : AbstractValidator<DeleteReplacedPartRequestModel>
    {
        public DeleteReplacedPartRequestModelValidator()
        {
            RuleFor(r => r.Id)
                .NotEqual(new Guid());
        }
    }
}
