using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IResult Add(Category category);
        IResult MultiAdd(Category[] categories);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}