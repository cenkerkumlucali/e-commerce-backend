using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerAddressService
    {
        IDataResult<List<CustomerAddress>> GetAll();
        IDataResult<List<CustomerAddress>> GetByCustomerId(int customerId);
        IResult Add(CustomerAddress customerAddress);
        IResult Delete(CustomerAddress customerAddress);
        IResult Update(CustomerAddress customerAddress);
    }
}