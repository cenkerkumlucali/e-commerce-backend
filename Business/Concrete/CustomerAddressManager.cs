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
    public class CustomerAddressManager:ICustomerAddressService
    {
        private ICustomerAddressDal _customerAddressDal;

        public CustomerAddressManager(ICustomerAddressDal customerAddressDal)
        {
            _customerAddressDal = customerAddressDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerAddressService")]
        [ValidationAspect(typeof(CustomerAddressValidator))]
        public async Task<IResult> Add(CustomerAddress customerAddress)
        {
            await _customerAddressDal.AddAsync(customerAddress);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerAddressService")]
        public async Task<IResult> Delete(CustomerAddress customerAddress)
        {
            await _customerAddressDal.DeleteAsync(customerAddress);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerAddressService")]
        [ValidationAspect(typeof(CustomerAddressValidator))]
        public async Task<IResult> Update(CustomerAddress customerAddress)
        {
            await _customerAddressDal.UpdateAsync(customerAddress);
            return new SuccessResult();
        }
        public async Task<IDataResult<List<CustomerAddress>>> GetAll()
        {
            return new SuccessDataResult<List<CustomerAddress>>(await _customerAddressDal.GetAllAsync());
        }

        public async Task<IDataResult<List<CustomerAddress>>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerAddress>>( await _customerAddressDal.GetAllAsync(c=>c.CustomerId==customerId));
        }

        public async Task<IDataResult<List<CustomerAddressDto>>> GetAllDatails()
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(await _customerAddressDal.GetCustomerAddressDetail());
        }

        public async Task<IDataResult<List<CustomerAddressDto>>> GetDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(
                await _customerAddressDal.GetCustomerAddressDetail(c => c.CustomerId == customerId));
        }

        public async Task<IDataResult<List<CustomerAddressDto>>> GetDetailsByAddressId(int addressId)
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(
                await _customerAddressDal.GetCustomerAddressDetail(c => c.AddressId == addressId));
        }
      
    }
}