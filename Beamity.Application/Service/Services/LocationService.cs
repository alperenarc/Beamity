using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly LocationRepository _repository;
        private readonly IMapper _mapper;
        public LocationService(LocationRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void CreateLocation(CreateLocationDTO input)
        {
            var location = _mapper.Map<Location>(input);
            _repository.Create(location);
        }

        public void DeleteLocation(DeleteLocationDTO input)
        {
            _repository.Delete(input.Id);
        }

        public List<ReadLocationDTO> GetAllLocation()
        {
            var locations = _repository.GetAll();
            var result = _mapper.Map<List<ReadLocationDTO>>(locations);
            return result;
        }

        public ReadLocationDTO GetLocation(EntityDTO input)
        {
            var location = _repository.GetById(input.Id);
            return _mapper.Map<ReadLocationDTO>(location);
        }

        public void UpdateLocation(UpdateLocationDTO input)
        {
            var location = _mapper.Map<Location>(input);
            _repository.Update(location);
        }
    }
}
