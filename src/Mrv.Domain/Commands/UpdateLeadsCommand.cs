using System;
using Mrv.Domain.Commands.Validations;

namespace Mrv.Domain.Commands
{
    public class UpdateLeadsCommand : LeadsCommand
    {
        public UpdateLeadsCommand(Guid newId, int category, int contact, string suburb,
            decimal price, string status, string description, DateTime dateCreated)
        {
            Id = newId;
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
            ValidationResult = new UpdateLeadsCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}