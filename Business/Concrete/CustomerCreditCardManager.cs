using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerCreditCardValidator))]
        public IResult Add(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Add(customerCreditCard);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Delete(customerCreditCard);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerCreditCardValidator))]
        public IResult Update(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Update(customerCreditCard);
            return new SuccessResult();
        }
        public IDataResult<List<CustomerCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CustomerCreditCard>> (_customerCreditCardDal.GetAll());
        }

        public IDataResult<List<CustomerCreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCreditCard>>(
                _customerCreditCardDal.GetAll(c => c.CustomerId == customerId));
        }


        public IDataResult<List<CustomerPaymentDetailDto>> GetDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerPaymentDetailDto>>(
                _customerCreditCardDal.GetDetails(c => c.UserId == customerId));
        }

    }
}