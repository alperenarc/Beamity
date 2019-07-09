using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.RelationDTO;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Index()
        {
            IEnumerable<ReadRelationDTO> relations = null;

            try
            {
                relations = _relationService.GetAllRelations();
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
    }
}