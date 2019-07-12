using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ProjectDTOs;
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
    public class ProjectService : IProjectService
    {
        private readonly IBaseGenericRepository<Project> _repository;
        private readonly IMapper _mapper;
        public ProjectService(IBaseGenericRepository<Project> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateProject(CreateProjectDTO input)
        {
            var project = _mapper.Map<Project>(input);
            await _repository.Create(project);
        }

        public async Task DeleteProject(DeleteProjectDTO input)
        {
            await _repository.Delete(input.Id);
        }
        public async Task<List<ReadProjectDTO>> GetAllProject()
        {
            var projects = await _repository.GetAll()
                .Where(z=>z.IsActive == true).ToListAsync();
            var result = _mapper.Map<List<ReadProjectDTO>>(projects);
            return result;
        }
        // EntityDTO is a Project Id.
        public async Task<ReadProjectDTO> GetProject(EntityDTO input)
        {
            var project = await _repository.GetById(input.Id);
            return _mapper.Map<ReadProjectDTO>(project);
        }

        public async Task UpdateProject(UpdateProjectDTO input)
        {
            var project = _mapper.Map<Project>(input);
            await _repository.Update(input.Id,project);
        }
    }
}
