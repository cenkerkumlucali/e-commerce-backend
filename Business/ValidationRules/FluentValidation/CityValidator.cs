using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CityValidator:AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.CountryId).NotEmpty().WithMessage("Ülke boş bırakılamaz");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Şehir ismi boş bırakılamaz");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Şehir ismi en az 2 karakterden oluşmalıdır");
            RuleFor(c => c.Name).MaximumLength(10).WithMessage("Şehir ismi en fazla 10 karakterden oluşmalıdır");
        }
    }
}