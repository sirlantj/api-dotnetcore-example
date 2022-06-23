using System;
using Mrv.Domain.Commands.Validations;

namespace Mrv.Domain.Commands
{
    public class RemoveLeadsCommand : LeadsCommand
    {
        public RemoveLeadsCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveLeadsCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}