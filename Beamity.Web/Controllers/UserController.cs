using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Profile(int id)
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserDTO user)
        {
            var result = _userService.Login(user);
            if (result != null)
            {
                const string Issuer = "https://localhost:44335/";
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Name, ClaimValueTypes.String, Issuer),
                    new Claim(ClaimTypes.Role, result.RoleName, ClaimValueTypes.String, Issuer),
                    //new Claim("Id", result.Id.ToString(), ClaimValueTypes.String, Issuer)

            };
                var userIdentity = new ClaimsIdentity("SuperSecureLogin");
                userIdentity.AddClaims(claims);
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });
                // Store User Id on session
                HttpContext.Session.SetString("UserId",result.Id.ToString());
                return RedirectToAction("Index", "Project");
            }
            else
            {
                return NotFound("User is not found !");
            }

        }


        [AllowAnonymous]
        // GET: User/Create
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(CreateUserDTO user)
        {
            try
            {
                _userService.Register(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return RedirectToAction(nameof(Verificate));
        }

        [AllowAnonymous]
        // GET: User/Create
        public ActionResult Verificate()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "User");
        }

    }
}