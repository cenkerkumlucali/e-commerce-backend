using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AddressManager:IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public IResult Add(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressAdded);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IAddressService.Get")]
        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(Messages.AddressDeleted);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(Messages.AddressUpdated);
        }
        [CacheAspect]
        public IDataResult<Address> GetById(int id)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(c => c.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(),Messages.AddressListed);
        }
        [CacheAspect]
        public IDataResult<List<Address>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(p => p.UserId == userId),"Kullanıcının adresi listelendi");
        }
        [CacheAspect]
        public IDataResult<List<Address>> GetAllByCityId(int cityId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(p => p.CityId == cityId),
                Messages.AddressFilterCityId);
        }
        
       
    }
}