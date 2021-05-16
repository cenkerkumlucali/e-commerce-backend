using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService:IGenericCrudOperationService<Category>
    {
        IResult Add(Category category);
        IResult MultiAdd(Category[] categories);
    }
}