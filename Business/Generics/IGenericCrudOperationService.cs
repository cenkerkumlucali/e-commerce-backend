using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Generics
{
    public interface IGenericCrudOperationService<T>
    {
        Task<IDataResult<List<T>>> GetAll();
        Task<IResult> Add(T entity);
        Task<IResult> Delete(T entity);
        Task<IResult> Update(T entity);
    }
}