﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IResult> Add(Favorite favorite)
        {
            await _favoriteDal.AddAsync(favorite);
            return new SuccessResult(Messages.FavoriteAdded);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Favorite favorite)
        {
            await _favoriteDal.DeleteAsync(favorite);
            return new SuccessResult(Messages.FavoriteDeleted);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Favorite favorite)
        {
            await _favoriteDal.UpdateAsync(favorite);
            return new SuccessResult(Messages.FavoriteUpdated);
        }
        public async Task<IDataResult<List<Favorite>>> GetAll()
        {
            return new SuccessDataResult<List<Favorite>>( await _favoriteDal.GetAllAsync());
        }
       

        public IDataResult<List<FavoriteDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetAllDetails());
        }

        public IDataResult<List<FavoriteDetailDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetAllDetails(c => c.UserId == userId));
        }

        public IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilteredAscByUserId(int userId)
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetAllDetails(c=>c.UserId==userId).OrderBy(c=>c.Price).ToList());
        }

        public IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilteredDescByUserId(int userId)
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetAllDetails(c=>c.UserId == userId).OrderByDescending(c=>c.Price).ToList());
        }
    }
}