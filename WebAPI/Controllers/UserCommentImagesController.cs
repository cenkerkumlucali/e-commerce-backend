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
    public class UserCommentImagesController : ControllerBase
    {
        private IUserCommentImageService _userCommentImageService;

        public UserCommentImagesController(IUserCommentImageService userCommentImageService)
        {
            _userCommentImageService = userCommentImageService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] List<IFormFile> file, [FromForm] UserCommentImage images)
        {
            var result = _userCommentImageService.AddAsync(file, images);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UserCommentImage image)
        {
            var result = _userCommentImageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userCommentImageService.GetImagesByTId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userCommentImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getimagesbyproductid")]
        public IActionResult GetImagesById([FromForm(Name = ("ProductId"))] int carId)
        {
            var result = _userCommentImageService.GetImagesByTId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
