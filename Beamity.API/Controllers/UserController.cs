using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login(LoginUserDTO user)
        {
            var check = _userService.Login(user);
            if (check.Equals(true))
            {
                return Ok();
            }
            return NotFound("User is not found !");
        }
        [HttpPost]
        public IActionResult Register(CreateUserDTO user)
        {
            try
            {
                _userService.Register(user);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the registration process. Please try again !");
            }
            return Ok("Registration process is success");

        }
        [HttpPut]
        public IActionResult UpdateProfile(UpdateUserDTO user)
        {
            try
            {
                _userService.UpdateProfile(user);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the editing process. Please try again !");
            }
            return Ok("Editing process is success");
        }
        
    }
}