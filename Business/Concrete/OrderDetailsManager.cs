using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderDetailsManager:IOrderDetailsService
    {
        private IOrderDetailsDal _orderDetailsDal;

        public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
        {
            _orderDetailsDal = orderDetailsDal;
        }

        public IDataResult<List<OrderDetails>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetails>>(_orderDetailsDal.GetAll());
        }

        public IResult Add(OrderDetails orderDetails)
        {
            _orderDetailsDal.Add(orderDetails);
            return new SuccessResult();
        }

        public IResult Delete(OrderDetails orderDetails)
        {
            _orderDetailsDal.Delete(orderDetails);
            return new SuccessResult();
        }

        public IResult Update(OrderDetails orderDetails)
        {
            _orderDetailsDal.Update(orderDetails);
            return new SuccessResult();
        }
    }
}