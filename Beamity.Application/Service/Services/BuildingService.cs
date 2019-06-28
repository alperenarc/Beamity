using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BuildingDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class BuildingService : IBuildingService
    {
        /*
         * This Class for define the Methods
         * This class contain 
         *  1.CreateBuilding
         *  2.DeleteBuilding
         *  3.GetAllBuildings
         *  4.GetBuilding
         *  5.UpdateBuilding methods
         */
        private readonly BuildingRepository _repository;
        private readonly IMapper _mapper;
        private readonly LocationRepository _locationRepository;
        public BuildingService(LocationRepository locationRepository, IMapper mapper, BuildingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            _locationRepository = locationRepository;
        }

        public void CreateBuilding(CreateBuildingDTO input)
        {
            var building = _mapper.Map<Building>(input);
            building.Location = _locationRepository.GetById(input.LocationId);
            _repository.Create(building);
        }

        public void DeleteBuilding(DeleteBuildingDTO input)
        {
            var building = _mapper.Map<Building>(input);
            _repository.Delete(building);
        }

        public List<ReadBuildingDTO> GetAllBuildings()
        {
            var building = _repository.GetAll();
            var result = _mapper.Map<List<ReadBuildingDTO>>(building);
            return result;
        }

        public ReadBuildingDTO GetBuilding(EntityDTO input)
        {
            var building = _repository.GetById(input.Id);
            var result = _mapper.Map<ReadBuildingDTO>(input);
            return result;
        }

        public void UpdateBuilding(UpdateBuildingDTO input)
        {
            var building = _mapper.Map<Building>(input);
            _repository.Update(building);
        }
    }
}
