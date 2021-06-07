using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IDataResult<List<Order>>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(await _orderDal.GetAllAsync());
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<long>> GetByIdAdd(Order orders)
        {
            await _orderDal.AddAsync(orders);
            return new SuccessDataResult<long>(orders.Id, Messages.AddedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(Order order)
        {
            await _orderDal.DeleteAsync(order);
            return new SuccessResult(Messages.DeletedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(Order order)
        {
            await _orderDal.UpdateAsync(order);
            return new SuccessResult(Messages.UpdatedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(Order order)
        {
            await _orderDal.AddAsync(order);
            return new SuccessResult();
        }
    }
}