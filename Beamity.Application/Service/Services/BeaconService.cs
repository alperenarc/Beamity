using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class BeaconService : IBeaconService
    {
        private readonly BeaconRepository _repository;
        public BeaconService(BeaconRepository repository)
        {
            _repository = repository;
        }
    }
}
