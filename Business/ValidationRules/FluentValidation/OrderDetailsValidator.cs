using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderDetailsValidator:AbstractValidator<OrderDetails>
    {
        public OrderDetailsValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.OrderId).NotEmpty();
            RuleFor(c => c.SalePrice).NotEmpty();
        }
    }
}