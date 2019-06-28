using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class ArtifactService : IService
    {
        private readonly ArtifactRepository _repository;
        public ArtifactService(ArtifactRepository repository)
        {
            _repository = repository;
        }
    }
}
