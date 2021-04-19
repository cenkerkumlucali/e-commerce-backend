using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderStatusService
    {
        IDataResult<List<OrderStatus>> GetAll();
        IResult Add(OrderStatus orderStatus);
        IResult Delete(OrderStatus orderStatus);
        IResult Update(OrderStatus orderStatus);
    }
}