using Business.Concrete;
using DataAccess.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Address.UnitTest
{
    [TestClass]
    public class AddressUnitTest
    {
        
        [TestMethod]
        public void Address_Add_UnitTest()
        {
            Moq.Mock<IAddressDal> mock = new Moq.Mock<IAddressDal>();
            AddressManager addressManager = new AddressManager(mock.Object);
            addressManager.Add(new Entities.Concrete.Address());

        }
    }
}
