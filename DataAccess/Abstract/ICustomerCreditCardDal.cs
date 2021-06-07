using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerCreditCardDal:IEntityRepository<CustomerCreditCard>
    {
       Task<List<CustomerPaymentDetailDto>> GetDetails(Expression<Func<CustomerPaymentDetailDto, bool>> filter = null);

    }
}