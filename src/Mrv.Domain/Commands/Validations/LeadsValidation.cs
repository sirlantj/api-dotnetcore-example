using System;
using FluentValidation;

namespace Mrv.Domain.Commands.Validations
{
    public abstract class LeadsValidation<T> : AbstractValidator<T> where T : LeadsCommand
    {
        protected void ValidateCategory()
        {
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Please ensure you have entered the Category");
        }

        protected void ValidateContact()
        {
            RuleFor(c => c.ContactId).NotEmpty().WithMessage("Please ensure you have entered the Conctact");
        }

        protected void ValidatePrice()
        {
            RuleFor(c => c.Price).NotEmpty().WithMessage("Please ensure you have entered the Price");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}