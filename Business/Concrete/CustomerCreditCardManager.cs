using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerCreditCardManager:ICustomerCreditCardService
    {
        private ICustomerCreditCardDal _customerCreditCardDal;

        public CustomerCreditCardManager(ICustomerCreditCardDal customerCreditCardDal)
        {
            _customerCreditCardDal = customerCreditCardDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerCreditCardValidator))]
        public async Task<IResult> Add(CustomerCreditCard customerCreditCard)
        {
            await _customerCreditCardDal.AddAsync(customerCreditCard);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(CustomerCreditCard customerCreditCard)
        {
            await _customerCreditCardDal.DeleteAsync(customerCreditCard);
            return new SuccessResult(Messages.DeletedCustomerCreditCard);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerCreditCardValidator))]
        public async Task<IResult> Update(CustomerCreditCard customerCreditCard)
        {
            await _customerCreditCardDal.UpdateAsync(customerCreditCard);
            return new SuccessResult();
        }
        public async Task<IDataResult<List<CustomerCreditCard>>> GetAll()
        {
            return new SuccessDataResult<List<CustomerCreditCard>> (await _customerCreditCardDal.GetAllAsync());
        }

        public async Task<IDataResult<List<CustomerCreditCard>>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCreditCard>>(
                await _customerCreditCardDal.GetAllAsync(c => c.CustomerId == customerId));
        }


        public async Task<IDataResult<List<CustomerPaymentDetailDto>>> GetDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerPaymentDetailDto>>(
                await _customerCreditCardDal.GetDetails(c => c.UserId == customerId));
        }

    }
}