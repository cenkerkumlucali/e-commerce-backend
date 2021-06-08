using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori ismi boş bırakılamaz");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Kategori en az 2 karakterden oluşmalıdır");
            RuleFor(c => c.Name).MaximumLength(15).WithMessage("Kategori en fazla 15 karakterden oluşmalıdır");
        }
    }
}