using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerCreditCardService
    {
        IDataResult<List<CustomerCreditCard>> GetAll();
        IDataResult<List<CustomerCreditCard>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerPaymentDetailDto>> GetDetailsByCustomerId(int customerId);
        IResult Add(CustomerCreditCard customerCreditCard);
        IResult Delete(CustomerCreditCard customerCreditCard);
        IResult Update(CustomerCreditCard customerCreditCard);
    }
}