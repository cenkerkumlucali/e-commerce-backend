using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderDetailsService
    {
        
        IDataResult<List<OrderDetails>> GetAll();
        IDataResult<List<OrderDetailsDto>> GetAllDetails();
        IDataResult<List<OrderDetailsDto>> GetAllDetailsByUserId(int userId);
        IResult Add(OrderDetails[] orderDetails);
        IResult Delete(OrderDetails orderDetails);
        IResult Update(OrderDetails orderDetails);
    }
}