using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerCreditCardValidator:AbstractValidator<CustomerCreditCard>
    {
        public CustomerCreditCardValidator()
        {
            RuleFor(c => c.CardId).NotEmpty();
        }
    }
}