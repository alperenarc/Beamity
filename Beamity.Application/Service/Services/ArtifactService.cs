using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class ArtifactService : IArtifactService
    {
        private readonly ArtifactRepository _repository;
        public ArtifactService(ArtifactRepository repository)
        {
            _repository = repository;
        }
    }
}
