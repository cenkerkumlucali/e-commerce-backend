using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerAddressDal : IEntityRepository<CustomerAddress>
    {
        List<CustomerAddressDto> GetCustomerAddressDetail(Expression<Func<CustomerAddressDto, bool>> filter = null);
    }
}