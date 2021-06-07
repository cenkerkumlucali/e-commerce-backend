using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService:IGenericCrudOperationService<Category>
    {
        Task<IResult> Add(Category category);
        Task<IResult> MultiAdd(Category[] categories);
    }
}