using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAddressService:IGenericCrudOperationService<Address>
    {
        Task<IDataResult<Address>> GetById(int id);
        Task<IDataResult<List<Address>>> GetAllByUserId(int userId);
        Task<IDataResult<List<Address>>> GetAllByCityId(int cityId);
    }
}