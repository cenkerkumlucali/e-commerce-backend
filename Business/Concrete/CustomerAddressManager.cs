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
    public class CustomerAddressManager:ICustomerAddressService
    {
        private ICustomerAddressDal _customerAddressDal;

        public CustomerAddressManager(ICustomerAddressDal customerAddressDal)
        {
            _customerAddressDal = customerAddressDal;
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerAddressService")]
        [ValidationAspect(typeof(CustomerAddressValidator))]
        public IResult Add(CustomerAddress customerAddress)
        {
            _customerAddressDal.Add(customerAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerAddressService")]
        public IResult Delete(CustomerAddress customerAddress)
        {
            _customerAddressDal.Delete(customerAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerAddressService")]
        [ValidationAspect(typeof(CustomerAddressValidator))]
        public IResult Update(CustomerAddress customerAddress)
        {
            _customerAddressDal.Update(customerAddress);
            return new SuccessResult();
        }
        public IDataResult<List<CustomerAddress>> GetAll()
        {
            return new SuccessDataResult<List<CustomerAddress>>(_customerAddressDal.GetAll());
        }

        public IDataResult<List<CustomerAddress>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerAddress>>(_customerAddressDal.GetAll(c=>c.CustomerId==customerId));
        }

        public IDataResult<List<CustomerAddressDto>>GetAllDatails()
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(_customerAddressDal.GetCustomerAddressDetail());
        }

        public IDataResult<List<CustomerAddressDto>> GetDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(
                _customerAddressDal.GetCustomerAddressDetail(c => c.CustomerId == customerId));
        }

        public IDataResult<List<CustomerAddressDto>> GetDetailsByAddressId(int addressId)
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(
                _customerAddressDal.GetCustomerAddressDetail(c => c.AddressId == addressId));
        }
      
    }
}