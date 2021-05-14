using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandImagesValidator:AbstractValidator<BrandImages>
    {
        public BrandImagesValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
        }
    }
}