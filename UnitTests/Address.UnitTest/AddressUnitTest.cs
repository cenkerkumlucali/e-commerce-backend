using System;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Xunit;

namespace Address.UnitTest
{
    [TestClass]
    public class AddressUnitTest
    {
        private AddressesController _addressesController;

        public AddressUnitTest(IAddressService addressService)
        {
            _addressesController= new AddressesController(addressService);
        }

        [Fact]
        public Task GetAllAddress()
        {
        var result = _addressesController.GetAllAsync();
        return  Assert.NotEmpty(result.Result);
        }
    }
}
