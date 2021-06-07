using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerAddressService:IGenericCrudOperationService<CustomerAddress>
    {
        Task<IDataResult<List<CustomerAddress>>> GetByCustomerId(int customerId);
        Task<IDataResult<List<CustomerAddressDto>>> GetAllDatails();
        Task<IDataResult<List<CustomerAddressDto>>> GetDetailsByCustomerId(int customerId);
        Task<IDataResult<List<CustomerAddressDto>>> GetDetailsByAddressId(int addressId);
    }
}