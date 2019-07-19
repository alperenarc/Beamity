using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs.AnalyticDTO;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnalyticController : ControllerBase
    {
        private readonly IAnalyticService _analyticService;
        public AnalyticController(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task CreateAnalytic( CreateAnalyticDTO input)
        {
            try
            {
                await _analyticService.CreateAnalytic(input);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}