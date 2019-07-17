using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        [HttpGet]
        public async Task<ReadContentDTO> GetContent(EntityDTO input)
        {
            try
            {
                var content = await _contentService.GetContent(input);
                return content;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<List<ReadContentDTO>> GetAllContents(EntityDTO input)
        {
            try
            {
                var contents = await _contentService.GetAllContents(input);
                return contents;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<List<ReadContentDTO>> GetHomeContents(EntityDTO input)
        {
            try
            {
                var contents = await _contentService.GetHomePageContents( input );
                return contents;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [AllowAnonymous]/*locationId*/
        public async Task<List<ReadContentDTO>> GetCampaignContents(EntityDTO input)
        {
            try
            {
                var contents = await _contentService.GetAllCampaignContents(input);
                return contents;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateContent(CreateContentDTO input)
        {
            try
            {
                await _contentService.CrateContent(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContent(UpdateContentDTO input)
        {
            try
            {
               await _contentService.UpdateContent(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContent(DeleteContentDTO input)
        {
            try
            {
                await _contentService.DeleteContent(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}