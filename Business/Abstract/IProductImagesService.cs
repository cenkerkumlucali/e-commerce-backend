using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImagesService:IGenericImagesService<ProductsImage>
    {
        IResult AddAsync(List<IFormFile> file, ProductsImage productsImage);
        IResult DeleteById(int id);
    }
}