using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(c => c.CityId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.AddressDetail).NotEmpty();
            RuleFor(c => c.AddressDetail).MinimumLength(5);
            RuleFor(c => c.AddressDetail).MaximumLength(100);
            RuleFor(c => c.AddressAbbreviation).NotEmpty();
            RuleFor(c => c.AddressAbbreviation).MaximumLength(25);
        }
    }
}