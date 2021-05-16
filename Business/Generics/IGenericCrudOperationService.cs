using System.Collections.Generic;
using Core.Utilities.Results;

namespace Business.Generics
{
    public interface IGenericCrudOperationService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}