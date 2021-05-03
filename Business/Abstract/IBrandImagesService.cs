using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IBrandImagesService
    {
        IResult Add(IFormFile file, BrandImages brandImages);
        IResult Delete(BrandImages brandImages);
        IResult Update(IFormFile file, BrandImages brandImages);
        IDataResult<BrandImages> Get(int id);
        IDataResult<List<BrandImages>> GetAll();
        IDataResult<List<BrandImages>> GetImagesByBrandId(int id);
    }
}