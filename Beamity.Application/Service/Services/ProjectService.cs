using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ProjectDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly GenericRepository<Project> _repository;
        private readonly IMapper _mapper;
        public ProjectService(GenericRepository<Project> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateProject(CreateProjectDTO input)
        {
            var project = _mapper.Map<Project>(input);
            await _repository.Create(project);
        }

        public void DeleteProject(DeleteProjectDTO input)
        {
            _repository.Delete(input.Id);
        }

        public async Task<List<ReadProjectDTO>> GetAllProject(string UserId)
        {
            var projects = await _repository.GetAll().Where(x => x.User.Id == Guid.Parse(UserId)).Include(z=>z.User).ToListAsync( );
            var result = _mapper.Map<List<ReadProjectDTO>>(projects);
            return result;
        }

        public ReadProjectDTO GetProject(EntityDTO input)
        {
            var project = _repository.GetById(input.Id);
            return _mapper.Map<ReadProjectDTO>(project);
        }

        public void UpdateProject(UpdateProjectDTO input)
        {
            var project = _mapper.Map<Project>(input);
            //_repository.Update(project);
        }
    }
}
