using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderStatusManager:IOrderStatusService
    {
        private IOrderStatusDal _orderStatusDal;

        public OrderStatusManager(IOrderStatusDal orderStatusDal)
        {
            _orderStatusDal = orderStatusDal;
        }

        public async Task<IDataResult<List<OrderStatus>>> GetAll()
        {
            return new SuccessDataResult<List<OrderStatus>>(await _orderStatusDal.GetAllAsync());
        }

        public async Task<IResult> Add(OrderStatus orderStatus)
        {
            await _orderStatusDal.AddAsync(orderStatus);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(OrderStatus orderStatus)
        {
            await _orderStatusDal.DeleteAsync(orderStatus);
            return new SuccessResult();
        }

        public async Task<IResult> Update(OrderStatus orderStatus)
        {
            await _orderStatusDal.UpdateAsync(orderStatus);
            return new SuccessResult();
        }
    }
}