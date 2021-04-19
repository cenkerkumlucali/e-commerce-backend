using System.Collections.Generic;
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

        public IDataResult<List<OrderStatus>> GetAll()
        {
            return new SuccessDataResult<List<OrderStatus>>(_orderStatusDal.GetAll());
        }

        public IResult Add(OrderStatus orderStatus)
        {
            _orderStatusDal.Add(orderStatus);
            return new SuccessResult();
        }

        public IResult Delete(OrderStatus orderStatus)
        {
            _orderStatusDal.Delete(orderStatus);
            return new SuccessResult();
        }

        public IResult Update(OrderStatus orderStatus)
        {
            _orderStatusDal.Update(orderStatus);
            return new SuccessResult();
        }
    }
}