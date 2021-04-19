using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<List<Basket>> GetAll();
        IResult Add(Basket basket);
        IResult Delete(Basket basket);
        IResult Update(Basket basket);
    }
}