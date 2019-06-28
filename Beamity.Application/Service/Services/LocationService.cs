using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly LocationRepository _repository;
        public LocationService(LocationRepository repository)
        {
            _repository = repository;
        }
    }
}
