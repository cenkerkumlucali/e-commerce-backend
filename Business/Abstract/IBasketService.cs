using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBasketService:IGenericCrudOperationService<Basket>
    {
        Task<IDataResult<List<BasketDetailDto>>> GetBasketDetails();
        Task<IDataResult<List<BasketDetailDto>>> GetBasketDetailsByUserId(int userId);
    }
}