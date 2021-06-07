using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService:IGenericCrudOperationService<Order>
    {
        Task<IDataResult<long>> GetByIdAdd(Order orders);
    }
}