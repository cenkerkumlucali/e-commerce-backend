using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
           _categoryDal.Add(category);
           return new SuccessResult();
        }

        public IResult MultiAdd(Category[] categories)
        {
            _categoryDal.MultiAdd(categories);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
          
            _categoryDal.Delete(category);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}