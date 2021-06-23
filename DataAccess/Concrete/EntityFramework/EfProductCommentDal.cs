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
    public class EfProductCommentDal:EfEntityRepositoryBase<ProductComment,NorthwindContext>,IProductCommentDal
    {
        public async Task<List<ProductCommentDto>> GetProductCommentDetail(Expression<Func<ProductCommentDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from productComment in context.ProductComments
                    join user in context.Users on productComment.UserId equals user.Id
                    join product in context.Products on productComment.ProductId equals product.Id
                    select new ProductCommentDto()
                    {
                        Id = productComment.Id,
                        UserId = user.Id,
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ImagePath = (from i in context.UserImages where i.UserId ==productComment.UserId select i.ImagePath).ToList(),
                        CommentImagePath = (from i in context.UserCommentImages where i.CommentId == productComment.Id select i).ToList(),
                        UserFullName = $"{user.FirstName} {user.LastName}",
                        Comment = productComment.Comment
                    };
                return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();
            }
        }
    }
}