using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerAddressManager:ICustomerAddressService
    {
        private ICustomerAddressDal _customerAddressDal;

        public CustomerAddressManager(ICustomerAddressDal customerAddressDal)
        {
            _customerAddressDal = customerAddressDal;
        }

        public IDataResult<List<CustomerAddress>> GetAll()
        {
            return new SuccessDataResult<List<CustomerAddress>>(_customerAddressDal.GetAll());
        }

        public IDataResult<List<CustomerAddress>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerAddress>>(_customerAddressDal.GetAll(c=>c.CustomerId==customerId));
        }

        public IResult Add(CustomerAddress customerAddress)
        {
           _customerAddressDal.Add(customerAddress);
           return new SuccessResult();
        }

        public IResult Delete(CustomerAddress customerAddress)
        {
            _customerAddressDal.Delete(customerAddress);
            return new SuccessResult();
        }

        public IResult Update(CustomerAddress customerAddress)
        {
            _customerAddressDal.Update(customerAddress);
            return new SuccessResult();
        }
    }
}