using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBrandService:IGenericCrudOperationService<Brand>
    {
        Task<IDataResult<List<BrandDetailDto>>> GetBrandDetails();
    }
}