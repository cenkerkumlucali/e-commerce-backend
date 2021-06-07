using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCommentController : ControllerBase
    {
        private IProductCommentService _productCommentService;

        public ProductCommentController(IProductCommentService productCommentService)
        {
            _productCommentService = productCommentService;
        }

        [HttpGet("getalldetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            var result = await _productCommentService.GetDetail();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getalldetailsbyuserid")]
        public async Task<IActionResult> GetAllDetailsByUserId(int userId)
        {
            var result = await _productCommentService.GetDetailByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getalldetailsbyproductid")]
        public async Task<IActionResult> GetAllDetailsByProductId(int productId)
        {
            var result = await _productCommentService.GetDetailByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productCommentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getallbyuserid")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var result = await _productCommentService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getallbyproductid")]
        public async Task<IActionResult> GetAllByProductId(int productId)
        {
            var result = await _productCommentService.GetAllByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductComment productComment)
        {
            var result = await _productCommentService.Add(productComment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}