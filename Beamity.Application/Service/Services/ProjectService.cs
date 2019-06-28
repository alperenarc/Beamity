using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepository _repository;
        public ProjectService(ProjectRepository repository)
        {
            _repository = repository;
        }
    }
}
