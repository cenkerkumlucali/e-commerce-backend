using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private ICustomerAddressService _customerAddressService;

        public CustomerAddressController(ICustomerAddressService customerAddressService)
        {
            _customerAddressService = customerAddressService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerAddressService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalldetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            var result = await _customerAddressService.GetAllDatails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbycustomerid")]
        public async Task<IActionResult> GetDetailsByCustomerId(int customerId)
        {
            var result = await _customerAddressService.GetDetailsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbyaddressid")]
        public async Task<IActionResult> GetDetailsByAddressId(int addressId)
        {
            var result = await _customerAddressService.GetDetailsByAddressId(addressId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var result = await _customerAddressService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CustomerAddress customerCreditCard)
        {
            var result = await _customerAddressService.Add(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(CustomerAddress customerCreditCard)
        {
            var result = await _customerAddressService.Delete(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CustomerAddress customerCreditCard)
        {
            var result = await _customerAddressService.Update(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}