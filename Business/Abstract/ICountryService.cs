using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IDataResult<List<Country>> GetAll();
        IResult Add(Country country);
        IResult Delete(Country country);
        IResult Update(Country country);
    }
}