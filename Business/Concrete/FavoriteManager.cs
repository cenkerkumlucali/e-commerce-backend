using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class FavoriteManager:IFavoriteService
    {
        private IFavoriteDal _favoriteDal;

        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        public IResult Add(Favorite favorite)
        {
            _favoriteDal.Add(favorite);
            return new SuccessResult(Messages.FavoriteAdded);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        public IResult Delete(Favorite favorite)
        {
            _favoriteDal.Delete(favorite);
            return new SuccessResult(Messages.FavoriteDeleted);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        public IResult Update(Favorite favorite)
        {
            _favoriteDal.Update(favorite);
            return new SuccessResult(Messages.FavoriteUpdated);
        }
        public IDataResult<List<Favorite>> GetAll()
        {
            return new SuccessDataResult<List<Favorite>>(_favoriteDal.GetAll());
        }
       

        public IDataResult<List<FavoriteDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetAllDetails());
        }
    }
}