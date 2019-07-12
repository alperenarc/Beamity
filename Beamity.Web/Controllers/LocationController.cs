using Beamity.Application.DTOs;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Web.Blob;
using Beamity.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Beamity.Web.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IBlobManager _blobManager;

        public LocationController(ILocationService locationService, IBlobManager blobManager)
        {
            _locationService = locationService;
            _blobManager = blobManager;
        }
        public async Task<IActionResult> Index()
        {
            
            EntityDTO dto = new EntityDTO()
            {
                Id = Guid.Parse(HttpContext.Session.GetString("UserId"))
            };
            IEnumerable<ReadLocationDTO> locations = await _locationService.GetAllLocationWithUser(dto);
            return View(locations);
        }
        public async Task<IActionResult> ChooseLocation()
        {
            //get user with Session
            EntityDTO dto = new EntityDTO()
            {
                Id = Guid.Parse(HttpContext.Session.GetString("UserId"))
            };
            IEnumerable<ReadLocationDTO> locations = await _locationService.GetAllLocationWithUser(dto);
            return View(locations);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationViewModel input)
        {
            try
            {
                string url = await _blobManager.UploadImageAsBlob(input.Photo);

                CreateLocationDTO data = new CreateLocationDTO()
                {
                    Name = input.Name,
                    PhotoURL = url,
                    ProjectId = input.ProjectId,
                    Latitude = input.Latitude,
                    Longitude = input.Longitude,
                    UserId = input.UserId
                };
                await _locationService.CreateLocation(data);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}