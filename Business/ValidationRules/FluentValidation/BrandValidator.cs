using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Marka ismi boş olamaz");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Marka ismi en az 2 karakterden oluşmalıdır");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Marka ismi en fazla 20 karakterden oluşmalıdır");
        }
    }
}