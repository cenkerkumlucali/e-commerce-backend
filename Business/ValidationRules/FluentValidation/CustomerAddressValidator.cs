using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerAddressValidator:AbstractValidator<CustomerAddress>
    {
        public CustomerAddressValidator()
        {
            RuleFor(c => c.AddressId).NotEmpty();
        }
    }
}