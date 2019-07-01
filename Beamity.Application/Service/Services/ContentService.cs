using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
        private readonly ContentRepository _repository;
        private readonly IMapper _mapper;
        public ContentService(ContentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CrateContent(CreateContentDTO input)
        {
            var content = _mapper.Map<Content>(input);
            _repository.Create(content);
        }

        public void DeleteContent(DeleteContentDTO input)
        {
            _repository.Delete(input.Id);
        }

        public List<ReadContentDTO> GetAllContents()
        {
            var contents = _repository.GetAll();
            var result = _mapper.Map<List<ReadContentDTO>>(contents);
            return result;
        }

        public ReadContentDTO GetContent(EntityDTO input)
        {
            var content = _repository.GetById(input.Id);
            var result = _mapper.Map<ReadContentDTO>(content);
            return result;
        }

        public List<ReadContentDTO> GetHomePageContents()
        {
            var contents = _repository.GetHomeContent();
            var result = _mapper.Map<List<ReadContentDTO>>(contents);
            return result;
        }

        public void UpdateContent(UpdateContentDTO input)
        {
            var content = _mapper.Map<Content>(input);
            _repository.Update(content);
        }
    }
}
