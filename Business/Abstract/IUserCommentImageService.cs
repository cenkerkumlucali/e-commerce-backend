using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUserCommentImageService:IGenericImagesService<UserCommentImage>
    {
        IResult AddAsync(List<IFormFile> file, UserCommentImage userCommentImage);
    }
}