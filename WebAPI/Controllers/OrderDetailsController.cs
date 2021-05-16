using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderDetailsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _orderDetailsService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getalldetailsbyuserid")]
        public IActionResult GetAllDetailsByUserId(int userId)
        {
            var result = _orderDetailsService.GetAllDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(OrderDetails[] orderDetails)
        {
            var result = _orderDetailsService.MultiAdd(orderDetails);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(OrderDetails orderDetails)
        {
            var result = _orderDetailsService.Delete(orderDetails);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(OrderDetails orderDetails)
        {
            var result = _orderDetailsService.Update(orderDetails);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
    }
}