using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerAddressDal:EfEntityRepositoryBase<CustomerAddress,NorthwindContext>,ICustomerAddressDal
    {
        public async Task<List<CustomerAddressDto>> GetCustomerAddressDetail(Expression<Func<CustomerAddressDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from customerAddress in context.CustomerAddresses
                    join user in context.Users on customerAddress.CustomerId equals user.Id
                    join address in context.Addresses on customerAddress.AddressId equals address.Id
                    select new CustomerAddressDto()
                    {
                        CustomerId = user.Id,
                        AddressId = address.Id,
                        CityId = address.CityId,
                        AddressDetail = address.AddressDetail,
                        AddressAbbreviation = address.AddressAbbreviation,
                        PostalCode = address.PostalCode,
                        CreateDate = address.CreateDate,
                        Active = address.Active
                    };
                return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();
            }


        }
    }
}