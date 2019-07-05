using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BuildingDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      
        private readonly IMapper _mapper;
        //private readonly IBaseGenericRepository<Building> _buildingRepository;
        //private readonly IBaseGenericRepository<Location> _locationRepository;
        private readonly LocationRepository _locationRepository;
        private readonly BuildingRepository _buildingRepository;

        public BuildingService( IMapper mapper, BuildingRepository buildingRepository,
             LocationRepository 
            locationRepository)
        {
            _mapper = mapper;
            _buildingRepository = buildingRepository;
            _locationRepository = locationRepository;
        }

        public void CreateBuilding(CreateBuildingDTO input)
        {
            
            try
            {
                var building = _mapper.Map<Building>(input);
                building.Location = _locationRepository.GetById(input.LocationId);
                _buildingRepository.Create(building);
            }
            catch (Exception e) 
            {

                throw e;
            }
            
           
        }

        public void DeleteBuilding(DeleteBuildingDTO input)
        {
            _buildingRepository.Delete(input.Id);
        }

        public List<ReadBuildingDTO> GetAllBuildings()
        {
            var query = _buildingRepository.GetAll();

            var buildings = query.ToList();

            List<ReadBuildingDTO> result = new List<ReadBuildingDTO>();
            foreach (var item in buildings)
            {
                ReadBuildingDTO dto = new ReadBuildingDTO();

                dto = _mapper.Map<ReadBuildingDTO>(item);
                dto.LocationName = item.Location.Name;

                result.Add(dto);
            }
            return result;
        }

        public ReadBuildingDTO GetBuilding(EntityDTO input)
        {
            var building = _buildingRepository.GetById(input.Id);
            var result = _mapper.Map<ReadBuildingDTO>(input);
            result.LocationName = building.Location.Name;
            return result;
        }

        

        public List<ReadBuildingDTO> GetBuildingsAtLocation(EntityDTO input)
        {
            var buildings = _buildingRepository
                .GetAll();
   

            List<ReadBuildingDTO> result = new List<ReadBuildingDTO>();
            
            foreach (var item in buildings)
            {
                ReadBuildingDTO dto = new ReadBuildingDTO();

                dto = _mapper.Map<ReadBuildingDTO>(item);
                dto.LocationName = item.Location.Name;

                result.Add(dto);
            }
            return result;
        }

        public void UpdateBuilding(UpdateBuildingDTO input)
        {
            var building = _mapper.Map<Building>(input);
            _buildingRepository.Update(building);
        }

    }
}
