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
            List<ReadLocationDTO> result = new List<ReadLocationDTO>();
            foreach (var item in locations)
            {
                ReadLocationDTO dto = new ReadLocationDTO();

                dto.Name = item.Name;
                dto.Latitude = item.Latitude;
                dto.Longitude = item.Longitude;
                dto.ProjectName = item.Project.Name;

                result.Add(dto);
            }
            return result;
        }

        public ReadLocationDTO GetLocation(EntityDTO input)
        {
            var location = _repository.GetById(input.Id);
            var result = _mapper.Map<ReadLocationDTO>(location);
            result.ProjectName = location.Project.Name;
            return result;
        }

        public void UpdateLocation(UpdateLocationDTO input)
        {
            var location = _mapper.Map<Location>(input);
            _repository.Update(location);
        }
    }
}
