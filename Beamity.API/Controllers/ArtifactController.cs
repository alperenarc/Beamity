using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ArtifactDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beamity.API.Controllers
{
  
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtifactController : ControllerBase
    {
        private readonly IArtifactService _artifactService;
        public ArtifactController(IArtifactService artifactService)
        {
            _artifactService = artifactService;
        }
        [HttpGet("{id}")]
        public async Task<ReadArtifactDTO> GetArtifact(EntityDTO input)
        {
            try
            {
                var artifact = await _artifactService.GetArtifact(input);
                return artifact;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        [AllowAnonymous]/*LocationId*/
        public async Task<List<ReadArtifactDTO>> GetAllArtifacts( EntityDTO input)
        {
            try
            {
               
                var artifacts = await _artifactService.GetAllArtifacts(input);
                return artifacts;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<List<ReadArtifactDTO>> GetArtifactsInRoom(EntityDTO input)
        {
            try
            {
                var artifacts = await _artifactService.GetArtifactsInRoom(input);
                return artifacts;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateArtifact(CreateArtifactDTO input)
        {
            try
            {
                await _artifactService.CreateArtifact(input);
                return Ok();
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateArtifact(UpdateArtifactDTO input)
        {
            try
            {
                await _artifactService.UpdateArtifact(input);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteArtifact(DeleteArtifactDTO input)
        {
            try
            {
                await _artifactService.DeleteArtifact(input);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}