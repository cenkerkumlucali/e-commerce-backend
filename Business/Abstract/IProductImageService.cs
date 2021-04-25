using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(IFormFile file, ProductsImage productsImage);
        IResult Delete(ProductsImage productsImage);
        IResult Update(IFormFile file, ProductsImage productsImage);
        IDataResult<ProductsImage> Get(int id);
        IDataResult<List<ProductsImage>> GetAll();
        IDataResult<List<ProductsImage>> GetImagesByProductId(int id);
    }
}