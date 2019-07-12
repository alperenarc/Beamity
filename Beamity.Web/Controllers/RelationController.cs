using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RelationDTO;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class RelationController : Controller
    {
        private readonly IRelationService _relationService;
        public RelationController(IRelationService relationService)
        {
            _relationService = relationService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReadRelationDTO> relations = null;
            var location = HttpContext.Session.GetString("LocationId");
            EntityDTO dto = new EntityDTO
            {
                Id = Guid.Parse(location)
            };
            try
            {
                relations = await _relationService.GetAllRelations(dto);
            }
            catch (Exception e)
            {

                throw e;
            }

            if (relations != null)
                return View(relations);
            else
            {
                return View();
            }
        }
        [HttpPut]
        public void UpdateRelation(UpdateRelationDTO input)
        {
            _relationService.UpdateRelation(input);
        }
    }
}