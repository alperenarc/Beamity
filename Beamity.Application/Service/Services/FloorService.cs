using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class FloorService : IFloorService
    {
        private readonly FloorRepository _repository;
        public FloorService(FloorRepository repository)
        {
            _repository = repository;
        }
    }
}
