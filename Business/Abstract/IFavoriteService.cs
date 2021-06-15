using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFavoriteService:IGenericCrudOperationService<Favorite>
    {
        IDataResult<List<FavoriteDetailDto>> GetAllDetails();
        IDataResult<List<FavoriteDetailDto>> GetDetailsByUserIdAndProductId(int userId,int productId);

        IDataResult<List<FavoriteDetailDto>> GetAllDetailsByUserId(int userId);
        IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilteredAscByUserId(int userId);
        IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilteredDescByUserId(int userId);
        Task<IDataResult<int>> GetByIdAdd(Favorite favorite);

    }
}