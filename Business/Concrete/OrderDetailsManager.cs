using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderDetailsManager:IOrderDetailsService
    {
        private IOrderDetailsDal _orderDetailsDal;

        public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
        {
            _orderDetailsDal = orderDetailsDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OrderDetailsValidator))]
        public async Task<IResult> MultiAdd(OrderDetails[] orderDetails)
        {
            await _orderDetailsDal.MultiAddAsync(orderDetails);
            return new SuccessResult();
        }

        public async Task<IResult> Add(OrderDetails order)
        {
            await _orderDetailsDal.AddAsync(order);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(OrderDetails orderDetails)
        {
            await _orderDetailsDal.DeleteAsync(orderDetails);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OrderDetailsValidator))]
        public async Task<IResult> Update(OrderDetails orderDetails)
        {
            await _orderDetailsDal.UpdateAsync(orderDetails);
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<List<OrderDetails>>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetails>>(await _orderDetailsDal.GetAllAsync());
        }
        [CacheAspect]
        public async Task<IDataResult<List<OrderDetailsDto>>> GetAllDetails()
        {
            return new SuccessDataResult<List<OrderDetailsDto>>( await _orderDetailsDal.GetProductDetails());
        }

        public async Task<IDataResult<List<OrderDetailsDto>>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(
                await _orderDetailsDal.GetProductDetails(c => c.UserId == userId));
        }
    }
}