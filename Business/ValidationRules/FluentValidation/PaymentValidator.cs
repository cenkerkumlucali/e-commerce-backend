using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator:AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(c => c.NameOnTheCard).NotEmpty().WithMessage("Kart üzerindeki isim boş geçilemez");
            RuleFor(c => c.NameOnTheCard).MinimumLength(5).WithMessage("Lütfen kart üzerindeki ismin karakterini 5 den fazla yazınız");
            RuleFor(c => c.NameOnTheCard).MaximumLength(30);
            RuleFor(c => c.CardNumber).NotEmpty().WithMessage("Kart numarası boş geçilemez");
            RuleFor(c => c.CardCvv).NotEmpty().WithMessage("Kart güvenlik numarası boş geçilemez");
            RuleFor(c => c.CardCvv).MaximumLength(3).WithMessage("Lütfen kart güvenlik numarasını doğru giriniz");
        }
    }
}