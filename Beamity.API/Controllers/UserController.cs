using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ConfirmDTO;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.DTOs.TokenDTOs;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IAuthenticationService authenticationService, IMapper mapper)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login(LoginUserDTO user)
        //{
            
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Register(CreateUserDTO user)
        //{
            

        //}
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
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ConfirmEmail(ConfirmationDTO input)
        {
            //confirmCode = HttpContext.Request.Query["guidcode"].ToString();
            try
            {
                _userService.ConfirmEmail(input.ConfirmCode);
                return Ok("Success");
            }
            catch (Exception)
            {
                return BadRequest("Wrong");
            }
        }

    }
}