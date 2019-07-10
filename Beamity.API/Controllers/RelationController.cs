using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
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
        public List<ReadRelationDTO> GetAllRelations()
        {

            try
            {
                var relations = _relationService.GetAllRelations();
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
        [HttpGet("{id}")]
        public ReadRelationDTO GetRelation(EntityDTO Relation)
        {

            var relation = _relationService.GetRelation(Relation);
            return relation;

        }
        [HttpPost]
        [AllowAnonymous]
        public ReadContentDTO GetContentWithBeacon(GetContentWithBeaconDTO input)
        {
            
            var content = _relationService.GetContentWithBeacon(input);
            if (content == null)
            {
                return null;
            }
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
        public void DeleteRelation(DeleteRelationDTO input)
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