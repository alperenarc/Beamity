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
        [HttpGet("{id}")]
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
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ReadContentDTO>> GetAllContents()
        {
            try
            {
                //it wrong it must be deleted from API 
                //Or App send LocationID
                EntityDTO dto = new EntityDTO();
                var contents = await _contentService.GetAllContents( dto );
                return contents;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ReadContentDTO>> GetHomeContents()
        {
            try
            {

                //it wrong it must be deleted from API 
                //Or App send ProjectID ++
                EntityDTO dto = new EntityDTO();
                var contents = await _contentService.GetHomePageContents( dto );
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