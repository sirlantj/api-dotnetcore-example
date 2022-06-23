namespace Mrv.Domain.Commands.Validations
{
    public class UpdateLeadsCommandValidation : LeadsValidation<UpdateLeadsCommand>
    {
        public UpdateLeadsCommandValidation()
        {
            ValidateCategory();
            ValidateContact();
            ValidatePrice();
        }
    }
}