using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ArtifactDTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
using Beamity.Application.DTOs.RelationDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly IRelationService _relationService;
        public RelationController(IRelationService relationService)
        {
            _relationService = relationService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ReadRelationDTO>> GetAllRelations()
        {
            var location = HttpContext.Session.GetString("LocationId");
            EntityDTO dto = new EntityDTO();
            dto.Id = Guid.Parse(location);
            
            try
            {
                var relations = await _relationService.GetAllRelations(dto);
                if(relations.Count > 0)
                {
                    return relations;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpGet]
        public async Task<ReadRelationDTO> GetRelation(EntityDTO Relation)
        {

            var relation = await _relationService.GetRelation(Relation);
            return relation;

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ReadContentDTO> GetContentWithBeacon(GetContentWithBeaconDTO input)
        {
            
            var content = await _relationService.GetContentWithBeacon(input);
            if (content == null)
            {
                return null;
            }
            return content;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<List<ReadRelationDTO>> GetRelationsWithArtifact(EntityDTO input)
        {

            var relations = await _relationService.GetRelationsWithArtifact(input);
            if (relations == null)
            {
                return null;
            }
            return relations;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ReadRelationDTO> GetRelationsWithContent(EntityDTO input)
        {

            var relation = await _relationService.GetRelationWithContent(input);
            if (relation == null)
            {
                return new ReadRelationDTO();
            }
            return relation;
        }
        [HttpPost]
        public async Task<ReadArtifactAndContentDTO> GetRelationWithBeacon(GetContentWithBeaconDTO input)
        {
            try
            {
                return await _relationService.GetRelationWithBeacon(input); 
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task CreateRelation(CreateRelationDTO input)
        {
            try
            {
                await _relationService.CreateRelation(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public async Task DeleteRelation(DeleteRelationDTO input)
        {
            try
            {
                await _relationService.DeleteRelationDTO(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        public async Task UpdateRelation(UpdateRelationDTO input)
        {
            try
            {
                await _relationService.UpdateRelation(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}