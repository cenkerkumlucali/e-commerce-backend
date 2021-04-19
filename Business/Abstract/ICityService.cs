using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);
    }
}