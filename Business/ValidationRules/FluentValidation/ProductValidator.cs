
using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Ürün ismi boş bırakılamaz");
            RuleFor(c => c.Name).MinimumLength(5).WithMessage("Ürün ismi en az 5 karakterden oluşmalıdır");
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("Ürün ismi en fazla 50 karakterden oluşmalıdır");
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Kategori boş geçilemez");
            RuleFor(c => c.BrandId).NotEmpty().WithMessage("Marka boş geçilemez");
            RuleFor(c => c.Code).NotEmpty().WithMessage("Ürün kodu boş geçilemez");
            RuleFor(c => c.Code).MinimumLength(2).WithMessage("Ürün kodu en az 2 karakterden oluşmalıdır");
            RuleFor(c => c.Code).MaximumLength(15).WithMessage("Ürün kodu en fazla 15 karakterden oluşmalıdır");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez");
            RuleFor(c => c.Description).MinimumLength(10).WithMessage("Ürün açıklaması en az 10 karakterden oluşmalıdır");
            RuleFor(c => c.Description).MaximumLength(500).WithMessage("Ürün açıklaması en fazla 500 karakterden oluşmalıdır");
        }


    }
}
