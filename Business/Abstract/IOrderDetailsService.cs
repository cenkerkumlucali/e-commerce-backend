using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderDetailsService:IGenericCrudOperationService<OrderDetails>
    {
        
        IDataResult<List<OrderDetailsDto>> GetAllDetails();
        IDataResult<List<OrderDetailsDto>> GetAllDetailsByUserId(int userId);
        IResult MultiAdd(OrderDetails[] orderDetails);
    }
}