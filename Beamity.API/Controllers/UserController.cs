using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Beamity.Application.DTOs;
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
    [Authorize]
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
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginUserDTO user)
        {
            var check = _userService.Login(user);
            if ( check )
            {
                var response = _authenticationService.CreateAccessTokenAsync(user.Email, user.Password);
                if (!response.Success)
                {
                    return BadRequest(response.Message);
                }

                AccessTokenResource accessTokenResource = new AccessTokenResource();
                accessTokenResource.AccessToken = response.Token.Token;
                accessTokenResource.RefreshToken = response.Token.RefreshToken.Token;
                accessTokenResource.Expiration = 30000/*response.Token.Expiration*/;


                return Ok(accessTokenResource);
            }
            return NotFound("User is not found !");
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(CreateUserDTO user)
        {
            try
            {
                _userService.Register(user);
            }
            catch (Exception e)
            {
                return  BadRequest(e.Message);
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