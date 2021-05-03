using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<List<Address>> GetAll();
        IDataResult<Address> GetById(int id);
        IDataResult<List<Address>> GetAllByUserId(int userId);
        IDataResult<List<Address>> GetAllByCityId(int cityId);
        IResult Add(Address address);
        IResult Delete(Address address);
        IResult Update(Address address);
    }
}