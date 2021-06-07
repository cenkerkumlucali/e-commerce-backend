using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerCreditCardDal:EfEntityRepositoryBase<CustomerCreditCard,NorthwindContext>,ICustomerCreditCardDal
    {
        public async Task<List<CustomerPaymentDetailDto>> GetDetails(Expression<Func<CustomerPaymentDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from customerCreditCard in context.CustomerCreditCards
                    join payment in context.Payments on customerCreditCard.CardId equals payment.Id
                    join user in context.Users on customerCreditCard.CustomerId equals user.Id
                    select new CustomerPaymentDetailDto()
                    {
                        CardId = customerCreditCard.CardId,
                        UserId = user.Id,
                        NameOnTheCard = payment.NameOnTheCard,
                        CardCvv = payment.CardCvv,
                        CardNumber = payment.CardNumber,
                        expirationDate = payment.expirationDate
                    };
                return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();
            }
        }
    }
}