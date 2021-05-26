using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager:IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<long> GetByIdAdd(Order orders)
        {
            _orderDal.Add(orders);
            return new SuccessDataResult<long>(orders.Id, Messages.AddedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.DeletedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.UpdatedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult();
        }
    }
}