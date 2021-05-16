using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IDataResult<int> GetByIdAdd(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessDataResult<int>(payment.Id,Messages.PaymentAdded);
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult();
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IResult IsCardExist(Payment payment)
        {
            var result = _paymentDal.Get(c =>
                c.NameOnTheCard == payment.NameOnTheCard && c.CardNumber == payment.CardNumber &&
                c.CardCvv == payment.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
       
    }
}
