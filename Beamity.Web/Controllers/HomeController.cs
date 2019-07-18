using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.Service.IServices;
using Beamity.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beamity.Web.Controllers
{
    [Authorize(Policy = "Common")]
    public class HomeController : Controller
    {
        private readonly IAnalyticService _analyticService;
        public HomeController(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }
        public async Task<IActionResult> Index()
        {
            var analytics = await _analyticService.GetAllBeaconsWithHours();
            IEnumerable<AnalyticViewModel> vm= analytics
                .GroupBy(row => new
                {
                    Beacon = row.BeaconName,
                    row.CreatedTime.Hour
                }).Select(grp => new AnalyticViewModel
                {
                    Name = grp.Key.Beacon,
                    Hour = grp.Key.Hour,
                    Count = grp.Count()
                });
                return View(vm);
        }

    }
}