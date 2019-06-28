using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly BuildingRepository _repository;
        public BuildingService(BuildingRepository repository)
        {
            _repository = repository;
        }
    }
}
