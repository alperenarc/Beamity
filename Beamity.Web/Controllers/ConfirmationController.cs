using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beamity.Web.Controllers
{
    [Authorize]

    public class ConfirmationController : Controller
    {
        [HttpGet]
        public async Task<IActionResult >Verification(string guidcode)
        {
            //guidcode = HttpContext.Request.Query["guidcode"].ToString();
            //ViewBag.Message = guidcode;
            //if (guidcode == null)
            //{
            //    return NotFound();
            //}

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/User/ConfirmEmail");
                try
                {
                    //var jsonInString = JsonConvert.SerializeObject( guidcode );
                    var responseTask = await client.PostAsync("?guidcode=",new StringContent(guidcode, Encoding.UTF8, "application/json"));

                }
                catch (Exception)
                {
                    if (guidcode == null)
                    {
                        return NotFound();
                    }
                }

            }




            return View();
        }
    }
}