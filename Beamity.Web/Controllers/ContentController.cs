using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Web.Blob;
using Beamity.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IBlobManager _blobManager;
        public ContentController(IContentService contentService,IBlobManager blobManager)
        {
            _blobManager = blobManager;
            _contentService = contentService;
        }
        public IActionResult Index()
        {
            IEnumerable<ReadContentDTO> buildings = _contentService.GetAllContents();
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
                    Text = input.Text
                };
                _contentService.CrateContent(data);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public IActionResult Update(EntityDTO input)
        {
            var content = _contentService.GetContent(input);
            UpdateContentViewModel data = new UpdateContentViewModel()
            {
                Name = content.Name,
                Description = content.Description,
                Title = content.Title,
                
                IsHomePage = content.IsHomePage,
                Text = content.Text,
                
            };
            return View(data);
        }

        [HttpPost]
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
                    Name = input.Name,
                    Description = input.Description,
                    Title = input.Title,
                    MainImageURL = mainImageUrl,
                    SlideImageURL = slideImageUrl,
                    VideoURL = videoUrl,
                    AudioURL = audioUrl,
                    IsHomePage = input.IsHomePage,
                    Text = input.Text,
                    CreatedTime = DateTime.Now
                };
                _contentService.UpdateContent(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}