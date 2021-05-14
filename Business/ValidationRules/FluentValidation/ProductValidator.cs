
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(5);
            RuleFor(c => c.Name).MaximumLength(50);
            RuleFor(c => c.CategoryId).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.Code).NotEmpty();
            RuleFor(c => c.Code).MinimumLength(2);
            RuleFor(c => c.Code).MaximumLength(15);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(10);
        }


    }
}
