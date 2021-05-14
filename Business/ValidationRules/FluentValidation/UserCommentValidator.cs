using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserCommentValidator:AbstractValidator<UserComment>
    {
        public UserCommentValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty().WithMessage("Ürün boş");
            RuleFor(c => c.UserId).NotEmpty().WithMessage("Yorum atabilmek için giriş yapmalısınız");
            RuleFor(c => c.Comment).NotEmpty().WithMessage("Yorum boş geçilemez");
            RuleFor(c => c.Comment).MaximumLength(200).WithMessage("Yorum en fazla 200 karakterden oluşmalıdır");
        }
    }
}   