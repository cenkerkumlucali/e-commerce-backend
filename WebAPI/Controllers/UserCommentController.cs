using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentController : ControllerBase
    {
        private IUserCommentService _userCommentService;

        public UserCommentController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userCommentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getallbyuserid")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var result = await _userCommentService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
       
        [HttpPost("add")]
        public async Task<IActionResult> Add(UserComment userComment)
        {
            var result = await _userCommentService.Add(userComment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(UserComment userComment)
        {
            var result = await _userCommentService.Delete(userComment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(UserComment userComment)
        {
            var result = await _userCommentService.Update(userComment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}