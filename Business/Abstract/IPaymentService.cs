using System;
using System.Collections.Generic;
using System.Text;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService:IGenericCrudOperationService<Payment>
    {
        IDataResult<int> GetByIdAdd(Payment fakeCard);
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Payment fakeCard);
    }
}
