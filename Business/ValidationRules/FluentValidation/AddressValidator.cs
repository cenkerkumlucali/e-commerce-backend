using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(c => c.CityId).NotEmpty().WithMessage("Şehir boş geçilemez");
            RuleFor(c => c.AddressDetail).NotEmpty().WithMessage("Adres detayı boş geçilemez");
            RuleFor(c => c.AddressDetail).MinimumLength(5).WithMessage("Adres detayı en az 5 karakterden oluşmalıdır");
            RuleFor(c => c.AddressDetail).MaximumLength(100).WithMessage("Adres detayı en fazla 100 karakterden oluşmalıdır");
            RuleFor(c => c.AddressAbbreviation).NotEmpty().WithMessage("Adres kısayolu boş geçilemez");
            RuleFor(c => c.AddressAbbreviation).MaximumLength(25).WithMessage("Adres kısayalı en fazla 25 karakterden oluşmalıdır");
        }
    }
}