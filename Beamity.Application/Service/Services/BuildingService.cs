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
        private readonly IBaseGenericRepository<Building> _buildingRepository;
        private readonly IBaseGenericRepository<Location> _locationRepository;
        public BuildingService( IMapper mapper, IBaseGenericRepository<Building> buildingRepository,
            IBaseGenericRepository<Location> locationRepository)
        {
            _mapper = mapper;
            _buildingRepository = buildingRepository;
            _locationRepository = locationRepository;
        }

        public async Task CreateBuildingAsync(CreateBuildingDTO input)
        {
            var building = _mapper.Map<Building>(input);
            building.Location = await _locationRepository.GetById(input.LocationId);
            
            await _buildingRepository.Create(building);
        }

        public async Task DeleteBuilding(DeleteBuildingDTO input)
        {
            await _buildingRepository.Delete(input.Id);
        }

        public async Task<IList<ReadBuildingDTO>> GetAllBuildings()
        {
            var query = _buildingRepository.GetAll().Where(x=>x.IsActive).Include(x=>x.Location);

            var buildings = await query.ToListAsync();

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

        public async Task<ReadBuildingDTO> GetBuilding(EntityDTO input)
        {
            var building = await  _buildingRepository.GetAll().Include(x=> x.Location).FirstOrDefaultAsync(x=> x.Id == input.Id);
            var result = _mapper.Map<ReadBuildingDTO>(input);
            result.LocationName = building.Location.Name;
            return result;
        }

        public Task<ReadBuildingDTO> GetBuildingAsync(EntityDTO input)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ReadBuildingDTO>> GetBuildingsAtLocation(EntityDTO input)
        {
            var buildings = await _buildingRepository
                .GetAll()
                .Include(x=>x.Location)
                .Where(x=>x.Location.Id == input.Id)
                .ToListAsync();


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

        public async Task UpdateBuilding(UpdateBuildingDTO input)
        {
    var building = _mapper.Map<Building>(input);
          await _buildingRepository.Update(input.Id,building);
        }
    }
}
