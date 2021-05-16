using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAddressService:IGenericCrudOperationService<Address>
    {
        IDataResult<Address> GetById(int id);
        IDataResult<List<Address>> GetAllByUserId(int userId);
        IDataResult<List<Address>> GetAllByCityId(int cityId);
    }
}