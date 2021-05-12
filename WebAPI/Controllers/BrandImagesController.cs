using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandImagesController : ControllerBase
    {
        private IGenericImagesService<BrandImages> _imagesService;

        public BrandImagesController(IGenericImagesService<BrandImages> brandImageService)
        {
            _imagesService = brandImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] BrandImages images)
        {
            var result = _imagesService.Add(file, images);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _imagesService.GetImagesByTId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesById([FromForm(Name = ("BrandId"))] int carId)
        {
            var result = _imagesService.GetImagesByTId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}