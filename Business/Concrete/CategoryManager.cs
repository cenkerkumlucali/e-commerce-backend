using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [CacheAspect]
        public async Task<IDataResult<List<Category>>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAllAsync());
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> Add(Category category)
        {
           await _categoryDal.AddAsync(category);
           return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> MultiAdd(Category[] categories)
        {
          await _categoryDal.MultiAddAsync(categories);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> Delete(Category category)
        {
          
            await _categoryDal.DeleteAsync(category);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> Update(Category category)
        {
            await _categoryDal.UpdateAsync(category);
            return new SuccessResult();
        }
    }
}