using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerCreditCardDal:EfEntityRepositoryBase<CustomerCreditCard,NorthwindContext>,ICustomerCreditCardDal
    {
        public List<CustomerPaymentDetailDto> GetDetails(Expression<Func<CustomerPaymentDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from customerCreditCard in context.CustomerCreditCards
                    join payment in context.Payments on customerCreditCard.CardId equals payment.Id
                    join user in context.Users on customerCreditCard.CustomerId equals user.Id
                    select new CustomerPaymentDetailDto()
                    {
                        PaymentId = customerCreditCard.CardId,
                        UserId = user.Id,
                        NameOnTheCard = payment.NameOnTheCard,
                        CardCvv = payment.CardCvv,
                        CardNumber = payment.CardNumber,
                        expirationDate = payment.expirationDate
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}