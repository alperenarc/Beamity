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
        public ReadArtifactDTO GetArtifact(EntityDTO input)
        {
            try
            {
                var artifact = _artifactService.GetArtifact(input);
                return artifact;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public List<ReadArtifactDTO> GetAllArtifacts()
        {
            try
            {
                var artifacts = _artifactService.GetAllArtifacts();
                return artifacts;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        [HttpGet("{id}")]
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
        [AllowAnonymous]
        public IActionResult CreateArtifact(CreateArtifactDTO input)
        {
            try
            {
                _artifactService.CreateArtifact(input);
                return Ok();
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        [HttpPut]
        public IActionResult UpdateArtifact(UpdateArtifactDTO input)
        {
            try
            {
                _artifactService.UpdateArtifact(input);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult DeleteArtifact(DeleteArtifactDTO input)
        {
            try
            {
                _artifactService.DeleteArtifact(input);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}