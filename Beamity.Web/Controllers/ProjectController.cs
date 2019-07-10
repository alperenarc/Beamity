using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.DTOs.ProjectDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            var userid = HttpContext.Session.GetString("UserId");
            IEnumerable<ReadProjectDTO> projects = await _projectService.GetAllProject(userid);
            return View(projects);
            
        }
        
    }
}