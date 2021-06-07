using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IBrandDal:IEntityRepository<Brand>
    {
        Task<List<BrandDetailDto>> GetBrandsDetails(Expression<Func<BrandDetailDto, bool>> filter = null);
    }
}