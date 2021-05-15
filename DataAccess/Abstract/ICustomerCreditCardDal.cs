using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerCreditCardDal:IEntityRepository<CustomerCreditCard>
    {
        List<CustomerPaymentDetailDto> GetDetails(Expression<Func<CustomerPaymentDetailDto, bool>> filter = null);

    }
}