using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerCreditCardService:IGenericCrudOperationService<CustomerCreditCard>
    {
        IDataResult<List<CustomerCreditCard>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerPaymentDetailDto>> GetDetailsByCustomerId(int customerId);
    }
}