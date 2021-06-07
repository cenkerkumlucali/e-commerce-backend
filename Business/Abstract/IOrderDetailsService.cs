using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderDetailsService:IGenericCrudOperationService<OrderDetails>
    {

        Task<IDataResult<List<OrderDetailsDto>>> GetAllDetails();
        Task<IDataResult<List<OrderDetailsDto>>> GetAllDetailsByUserId(int userId);
        Task<IResult> MultiAdd(OrderDetails[] orderDetails);
    }
}