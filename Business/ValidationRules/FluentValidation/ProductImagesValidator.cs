using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class ProductImagesValidator:AbstractValidator<ProductsImage>
    {
        public ProductImagesValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
        }
    }
}
