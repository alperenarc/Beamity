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
        public async Task<IActionResult> CreateProject(CreateProjectDTO input)
        {
            try
            {
                await _projectService.CreateProject(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the creating process. Please try again !");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectDTO input)
        {
            try
            {
                await _projectService.UpdateProject(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the updating process. Please try again !");
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(DeleteProjectDTO input)
        {
            try
            {
                await _projectService.DeleteProject(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the deleting process. Please try again !");
            }
        }
        [HttpGet]
        public async Task<List<ReadProjectDTO>> GetAllProject()
        {
            var list = await _projectService.GetAllProject();
            return list;
        }
        [HttpGet]
        public async Task<ReadProjectDTO> GetProject(EntityDTO input)
        {
            var project = await _projectService.GetProject(input);
            return project;
        }

    }

}