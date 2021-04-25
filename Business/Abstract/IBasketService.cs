using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<List<Basket>> GetAll();
        IDataResult<List<BasketDetailDto>> GetBasketDetails();
        IResult Add(Basket basket);
        IResult Delete(Basket basket);
        IResult Update(Basket basket);
    }
}