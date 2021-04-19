using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderDetailsService
    {
        
        IDataResult<List<OrderDetails>> GetAll();
        IResult Add(OrderDetails orderDetails);
        IResult Delete(OrderDetails orderDetails);
        IResult Update(OrderDetails orderDetails);
    }
}