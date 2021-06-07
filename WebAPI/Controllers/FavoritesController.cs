using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.VisualBasic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _favoriteService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetailsfilteredascbyuserid")]
        public IActionResult GetAllDetailsFilteredAscByUserId(int userId)
        {
            var result = _favoriteService.GetAllDetailsFilteredAscByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getalldetailsfiltereddescbyuserid")]
        public IActionResult GetAllDetailsFilteredDescByUserId(int userId)
        {
            var result = _favoriteService.GetAllDetailsFilteredDescByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _favoriteService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getalldetailsbyuserid")]
        public IActionResult GetAllDetailsByUserId(int userId)
        {
            var result = _favoriteService.GetAllDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(Favorite favorite)
        {
            var result = await _favoriteService.Add(favorite);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(Favorite favorite)
        {
            var result = await _favoriteService.Delete(favorite);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
