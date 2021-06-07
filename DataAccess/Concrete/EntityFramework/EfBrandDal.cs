using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal:EfEntityRepositoryBase<Brand,NorthwindContext>,IBrandDal
    {
        public async Task<List<BrandDetailDto>> GetBrandsDetails(Expression<Func<BrandDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from brand in context.Brands
                    select new BrandDetailDto
                    {
                        BrandId = brand.Id,
                        BrandName = brand.Name,
                        Images = (from images in context.BrandsImages where images.BrandId==brand.Id select images.ImagePath).ToList()
                    };
                return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();
            }
        }
    }
}