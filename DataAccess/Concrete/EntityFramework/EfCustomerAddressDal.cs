using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerAddressDal:EfEntityRepositoryBase<CustomerAddress,NorthwindContext>,ICustomerAddressDal
    {
        
    }
}