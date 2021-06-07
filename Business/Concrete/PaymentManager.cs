using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IDataResult<int>> GetByIdAdd(Payment payment)
        {
            await _paymentDal.AddAsync(payment);
            return new SuccessDataResult<int>(payment.Id,Messages.PaymentAdded);
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidator))]
        public async Task<IResult> Update(Payment payment)
        {
            await _paymentDal.UpdateAsync(payment);
            return new SuccessResult();
        }

        public async Task<IResult> Add(Payment payment)
        {
            await _paymentDal.AddAsync(payment);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Payment payment)
        {
            await _paymentDal.DeleteAsync(payment);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Payment>>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(await _paymentDal.GetAllAsync());
        }

        public async Task<IDataResult<Payment>> GetById(int id)
        {
            return new SuccessDataResult<Payment>(await _paymentDal.GetAsync(c => c.Id == id));
        }

        public async Task<IDataResult<List<Payment>>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Payment>>(await _paymentDal.GetAllAsync(c => c.CardNumber == cardNumber));
        }

        public async Task<IResult> IsCardExist(Payment payment)
        {
            var result = await _paymentDal.GetAsync(c =>
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
