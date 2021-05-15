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
        IPaymentDal _fakeCardDal;

        public PaymentManager(IPaymentDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IDataResult<int> Add(Payment fakeCard)
        {
            _fakeCardDal.Add(fakeCard);
            return new SuccessDataResult<int>(fakeCard.Id,Messages.PaymentAdded);
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment fakeCard)
        {
            _fakeCardDal.Update(fakeCard);
            return new SuccessResult();
        }
        public IResult Delete(Payment fakeCard)
        {
            _fakeCardDal.Delete(fakeCard);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_fakeCardDal.GetAll());
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_fakeCardDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Payment>>(_fakeCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IResult IsCardExist(Payment fakeCard)
        {
            var result = _fakeCardDal.Get(c =>
                c.NameOnTheCard == fakeCard.NameOnTheCard && c.CardNumber == fakeCard.CardNumber &&
                c.CardCvv == fakeCard.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
       
    }
}
