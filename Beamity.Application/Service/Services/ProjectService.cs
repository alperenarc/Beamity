using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ProjectDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepository _repository;
        private readonly IMapper _mapper;
        public ProjectService(ProjectRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void CreateProject(CreateProjectDTO input)
        {
            var project = _mapper.Map<Project>(input);
            _repository.Create(project);
        }

        public void DeleteProject(DeleteProjectDTO input)
        {
            _repository.Delete(input.Id);
        }

        public List<ReadProjectDTO> GetAllProject()
        {
            var projects = _repository.GetAll();
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
            _repository.Update(project);
        }
    }
}
