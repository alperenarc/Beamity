using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
using Beamity.Application.Service.IServices;
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
        public List<ReadRelationDTO> GetAllRelations()
        {
            var relations = _relationService.GetAllRelations();
            return relations;
        }
        [HttpGet]
        public ReadRelationDTO GetRelation(EntityDTO Relation)
        {

            var relation = _relationService.GetRelation(Relation);
            return relation;

        }
        [HttpPost]
        public ReadContentDTO GetContentWithBeacon(GetContentWithBeaconDTO input)
        {
            var content = _relationService.GetContentWithBeacon(input);
            return content;
        }
        [HttpPost]
        public void CreateRelation(CreateRelationDTO input)
        {
            try
            {
                _relationService.CreateRelation(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public void DeleteRelationDTO(DeleteRelationDTO input)
        {
            try
            {
                _relationService.DeleteRelationDTO(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        public void UpdateRelation(UpdateRelationDTO input)
        {
            try
            {
                _relationService.UpdateRelation(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}