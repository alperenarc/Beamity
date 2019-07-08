using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ProjectDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateProject(CreateProjectDTO input)
        {
            try
            {
                _projectService.CreateProject(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the creating process. Please try again !");
            }
        }
        [HttpPut]
        public IActionResult UpdateProject(UpdateProjectDTO input)
        {
            try
            {
                _projectService.UpdateProject(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the updating process. Please try again !");
            }

        }
        [HttpDelete]
        public IActionResult DeleteProject(DeleteProjectDTO input)
        {
            try
            {
                _projectService.DeleteProject(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the deleting process. Please try again !");
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public List<ReadProjectDTO> GetAllProject()
        {
            var list = _projectService.GetAllProject();
            return list;
        }
        [HttpGet("{id}")]
        public ReadProjectDTO GetProject(EntityDTO input)
        {
            var project = _projectService.GetProject(input);
            return project;
        }

    }

}