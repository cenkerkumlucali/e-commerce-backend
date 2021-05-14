using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OrderDetailsValidator))]
        public IResult Add(OrderDetails[] orderDetails)
        {
            _orderDetailsDal.MultiAdd(orderDetails);
            return new SuccessResult();
        }

        public IResult Delete(OrderDetails orderDetails)
        {
            _orderDetailsDal.Delete(orderDetails);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OrderDetailsValidator))]
        public IResult Update(OrderDetails orderDetails)
        {
            _orderDetailsDal.Update(orderDetails);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<OrderDetails>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetails>>(_orderDetailsDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<OrderDetailsDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(_orderDetailsDal.GetProductDetails());
        }

        public IDataResult<List<OrderDetailsDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(
                _orderDetailsDal.GetProductDetails(c => c.UserId == userId));
        }
    }
}