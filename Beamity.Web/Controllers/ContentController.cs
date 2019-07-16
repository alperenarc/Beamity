using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ContentDTOs;
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
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IBlobManager _blobManager;
        public ContentController(IContentService contentService,IBlobManager blobManager)
        {
            _blobManager = blobManager;
            _contentService = contentService;
        }
        public async Task<IActionResult> Index()
        {
            //it's temporary 
            //get project ID
            EntityDTO dto = new EntityDTO()
            {
                Id = Guid.Parse(HttpContext.Session.GetString("LocationId"))
            };
            IEnumerable<ReadContentDTO> buildings = await _contentService.GetAllContents( dto );
            return View(buildings);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task Create(CreateContentViewModel input)
        {
            try
            {
                string mainImageUrl = await _blobManager.UploadImageAsBlob(input.MainImage);
                string slideImageUrl = await _blobManager.UploadImageAsBlob(input.SlideImage);
                string videoUrl = await _blobManager.UploadImageAsBlob(input.Video);
                string audioUrl = await _blobManager.UploadImageAsBlob(input.Audio);
                CreateContentDTO data = new CreateContentDTO()
                {
                    Name = input.Name,
                    Description = input.Description,
                    Title = input.Title,
                    MainImageURL = mainImageUrl,
                    SlideImageURL = slideImageUrl,
                    VideoURL = videoUrl,
                    AudioURL = audioUrl,
                    IsHomePage = input.IsHomePage,
                    IsCampaign = input.IsCampaign,
                    Text = input.Text,
                    LocationId = input.LocationId
                };
                await _contentService.CrateContent(data);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<IActionResult> Update(EntityDTO input)
        {
            var content = await _contentService.GetContent(input);
            UpdateContentViewModel data = new UpdateContentViewModel()
            {
                Id = input.Id,
                Name = content.Name,
                Description = content.Description,
                Title = content.Title,
                
                IsHomePage = content.IsHomePage,
                IsCampaign = content.IsCampaign,
                Text = content.Text,
                
            };
            return View(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContentViewModel input)
        {
            try
            {
                string mainImageUrl = await _blobManager.UploadImageAsBlob(input.MainImage);
                string slideImageUrl = await _blobManager.UploadImageAsBlob(input.SlideImage);
                string videoUrl = await _blobManager.UploadImageAsBlob(input.Video);
                string audioUrl = await _blobManager.UploadImageAsBlob(input.Audio);
                UpdateContentDTO data = new UpdateContentDTO()
                {
                    Id = input.Id,
                    Name = input.Name,
                    Description = input.Description,
                    Title = input.Title,
                    MainImageURL = mainImageUrl,
                    SlideImageURL = slideImageUrl,
                    VideoURL = videoUrl,
                    AudioURL = audioUrl,
                    IsHomePage = input.IsHomePage,
                    IsCampaign = input.IsCampaign,
                    Text = input.Text,
                    CreatedTime = DateTime.Now,
                    LocationId =input.LocationId
                };
                await _contentService.UpdateContent(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}