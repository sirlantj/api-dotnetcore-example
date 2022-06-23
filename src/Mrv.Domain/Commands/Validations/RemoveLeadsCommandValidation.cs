namespace Mrv.Domain.Commands.Validations
{
    public class RemoveLeadsCommandValidation : LeadsValidation<RemoveLeadsCommand>
    {
        public RemoveLeadsCommandValidation()
        {
            ValidateId();
        }
    }
}