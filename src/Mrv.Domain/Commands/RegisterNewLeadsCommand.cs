using System;
using Mrv.Domain.Commands.Validations;

namespace Mrv.Domain.Commands
{
    public class RegisterNewLeadsCommand : LeadsCommand
    {
        public RegisterNewLeadsCommand(int category, int contact, string suburb,
            decimal price, string status, string description, DateTime dateCreated)
        {
            CategoryId = category;
            ContactId = contact;
            Suburb = suburb;
            Price = price;
            Status = status;
            Description = description;
            DateCreated = dateCreated;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewLeadsCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}