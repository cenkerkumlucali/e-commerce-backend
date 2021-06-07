using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService:IGenericCrudOperationService<Payment>
    {
        Task<IDataResult<int>> GetByIdAdd(Payment fakeCard);
        Task<IDataResult<Payment>> GetById(int id);
        Task<IDataResult<List<Payment>>> GetByCardNumber(string cardNumber);
        Task<IResult> IsCardExist(Payment fakeCard);
    }
}
