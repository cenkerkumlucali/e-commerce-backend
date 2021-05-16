using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerAddressService:IGenericCrudOperationService<CustomerAddress>
    {
        IDataResult<List<CustomerAddress>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerAddressDto>> GetAllDatails();
        IDataResult<List<CustomerAddressDto>> GetDetailsByCustomerId(int customerId);
        IDataResult<List<CustomerAddressDto>> GetDetailsByAddressId(int addressId);
    }
}