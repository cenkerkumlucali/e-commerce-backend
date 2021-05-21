using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFavoriteService:IGenericCrudOperationService<Favorite>
    {
        IDataResult<List<FavoriteDetailDto>> GetAllDetails();
    }
}