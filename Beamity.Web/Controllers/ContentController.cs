using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        public IActionResult Index()
        {
            IEnumerable<ReadContentDTO> buildings = _contentService.GetAllContents();
            return View(buildings);
        }
    }
}