using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;
        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpGet("getbyusersdetails")]
        public IActionResult GetUsersDetails()
        {
            var result = _userService.GetUsersDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyusersdetailsbyid")]
        public IActionResult GetUserDetailsById(int userId)
        {
            var result = _userService.GetUserDetailsById(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateprofile")]
        public IActionResult ProfileUpdate(UserForUpdateDto userForUpdateDto)
        {
            var result = _userService.EditProfil(userForUpdateDto.User);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("createpasswordhash")]
        public IActionResult CreatePasswordHash(string password)
        {
            var result = _authService.CreatePasswordHash(password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("editpassword")]
        public IActionResult EditPassword(UserForUpdateDto userForUpdateDto, string newPassword, string newPasswordVerify)
        {
            var result = _userService.EditPassword(userForUpdateDto, newPassword, newPasswordVerify);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("email")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            if (result.Success)
            {
                return Ok(new
                {
                    result.Data.Id,
                    result.Data.FirstName,
                    result.Data.LastName,
                    result.Data.Email,
                    result.Data.Status
                });
            }
            return BadRequest(result);
        }

    }
}
