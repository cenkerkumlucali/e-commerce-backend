using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreditCardController : ControllerBase
    {
        private ICustomerCreditCardService _customerCreditCardService;

        public CustomerCreditCardController(ICustomerCreditCardService customerCreditCardService)
        {
            _customerCreditCardService = customerCreditCardService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerCreditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var result = await _customerCreditCardService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbycustomerid")]
        public async Task<IActionResult> GetDetailsByCustomerId(int customerId)
        {
            var result = await _customerCreditCardService.GetDetailsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CustomerCreditCard customerCreditCard)
        {
            var result = await _customerCreditCardService.Add(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(CustomerCreditCard customerCreditCard)
        {
            var result = await _customerCreditCardService.Delete(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CustomerCreditCard customerCreditCard)
        {
            var result = await _customerCreditCardService.Update(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
