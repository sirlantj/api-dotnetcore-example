namespace Mrv.Domain.Commands.Validations
{
    public class RegisterNewLeadsCommandValidation : LeadsValidation<RegisterNewLeadsCommand>
    {
        public RegisterNewLeadsCommandValidation()
        {
            ValidateCategory();
            ValidateContact();
            ValidatePrice();
        }
    }
}