using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class ContentService : IContentService
    {
        /*
         * This Class for define the Methods
         * This class contain 
         *  1.CrateContent
         *  2.DeleteContent
         *  3.GetAllContents
         *  4.GetHomePageContents
         *  5.UpdateContent methods
         */
        private readonly IBaseGenericRepository<Content> _repository;
        private readonly IBaseGenericRepository<Location> _locationRepository;
        private readonly IMapper _mapper;
        public ContentService(IBaseGenericRepository<Content> repository, IBaseGenericRepository<Location> locationRepository, IMapper mapper)
        {
            _repository = repository;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task CrateContent(CreateContentDTO input)
        {
            var content = _mapper.Map<Content>(input);
            content.Location = await _locationRepository.GetById(input.LocationId);
            await _repository.Create(content);
        }

        public async Task DeleteContent(DeleteContentDTO input)
        {
            await _repository.Delete(input.Id);
        }

        public async Task<List<ReadContentDTO>> GetAllCampaignContents(EntityDTO input)
        {
            var contents = await _repository
               .GetAll()
               .Include(x => x.Location)
               .Where(x => x.IsActive && x.IsCampaign  && x.Location.Id == input.Id)
               .ToListAsync();

            var result = _mapper.Map<List<ReadContentDTO>>(contents);
            return result;
        }

        //LocationID
        public async Task<List<ReadContentDTO>> GetAllContents(EntityDTO input)
        {
            var contents = await _repository
                .GetAll()
                .Include( x=> x.Location)
                .Where(x => x.IsActive && x.Location.Id == input.Id)
                .ToListAsync();

            var result = _mapper.Map<List<ReadContentDTO>>(contents);
            return result;
        }

        public async Task<ReadContentDTO> GetContent(EntityDTO input)
        {
            var content = await _repository.GetById(input.Id);
            var result = _mapper.Map<ReadContentDTO>(content);
            return result;
        }
        //Location ID
        public async Task<List<ReadContentDTO>> GetHomePageContents( EntityDTO input)
        {
            var contents = await _repository
                .GetAll()
                .Include( x=> x.Location)
                .Where(x => x.IsHomePage && x.IsActive && x.Location.Id == input.Id)
                .ToListAsync();
            var result = _mapper.Map<List<ReadContentDTO>>(contents);
            return result;
        }

        public async Task UpdateContent(UpdateContentDTO input)
        {
            var c = await _repository.GetById(input.Id);

            c.IsHomePage = input.IsHomePage;
            c.IsCampaign = input.IsCampaign;
            if( !string.IsNullOrEmpty(input.MainImageURL)  )
                c.MainImageURL = input.MainImageURL;
            if ( !string.IsNullOrEmpty(input.SlideImageURL))
                c.SlideImageURL = input.SlideImageURL;
            if ( !string.IsNullOrEmpty(input.VideoURL))
                c.VideoURL = input.VideoURL;
            if ( !string.IsNullOrEmpty(input.AudioURL))
                c.AudioURL = input.AudioURL;
            c.Name = input.Name;
            c.Title = input.Title;
            c.Description = input.Description;
            c.Text = input.Text;
            c.CreatedTime = input.CreatedTime;
            await _repository.Update(c.Id,c);
        }
    }
}
