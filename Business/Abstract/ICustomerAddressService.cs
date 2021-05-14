using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerAddressService
    {
        IDataResult<List<CustomerAddress>> GetAll();
        IDataResult<List<CustomerAddress>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerAddressDto>> GetAllDatails();
        IDataResult<List<CustomerAddressDto>> GetDetailsByCustomerId(int customerId);
        IDataResult<List<CustomerAddressDto>> GetDetailsByAddressId(int addressId);
        IResult Add(CustomerAddress customerAddress);
        IResult Delete(CustomerAddress customerAddress);
        IResult Update(CustomerAddress customerAddress);
    }
}