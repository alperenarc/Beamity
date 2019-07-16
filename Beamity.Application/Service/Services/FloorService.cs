using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.FloorDTOs;
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
    public class FloorService : IFloorService
    {
        /*
         * This Class for define the Methods
         * This class contain 
         *  1.Create Floor
         *  2.Delete Floor
         *  3.Get All Floor
         *  4.Get Floor
         *  5.Update Floor methods
         */
        private readonly IBaseGenericRepository<Floor> _repository;
        private readonly IBaseGenericRepository<Building> _buildingRepository;
        private readonly IMapper _mapper;

        public FloorService(IBaseGenericRepository<Floor> repository, IBaseGenericRepository<Building> buildingRepository, IMapper mapper)
        {
            _mapper = mapper; // define class of mapper library
            _buildingRepository = buildingRepository;
            _repository = repository;
        }

        public async Task CreateFloor(CreateFloorDTO input)
        {
            var floor = _mapper.Map<Floor>(input);
            floor.Building = await _buildingRepository.GetById(input.BuildingId); //firstly you must get building with building ID
            await _repository.Create(floor); // and then you can push on create method
        }

        public async Task DeleteFloor(DeleteFloorDTO input)
        {
            await _repository.Delete(input.Id);
        }
        //LocationID
        public async Task<List<ReadFloorDTO>> GetAllFloor(EntityDTO input)
        {
            var floors = await _repository
                .GetAll()
                .Include(x => x.Building)
                .ThenInclude(a => a.Location)
                .Where(x => x.Building.Location.Id == input.Id)
                .ToListAsync();
            List<ReadFloorDTO> result = new List<ReadFloorDTO>();
            foreach (var item in floors)
            {
                ReadFloorDTO dto = new ReadFloorDTO();

                dto = _mapper.Map<ReadFloorDTO>(item);
                dto.BuildingName = item.Building.Name;

                result.Add(dto);
            }
            return result;
        }
        //FloorID
        public async Task<ReadFloorDTO> GetFloor(EntityDTO input)
        {
            //var floor = await _repository.GetById(input.Id);
            var floor = await _repository
                .GetAll()
                .Include(x => x.Building)
                .FirstOrDefaultAsync(x => x.IsActive && x.Id == input.Id);
            var result = _mapper.Map<ReadFloorDTO>(floor);
            result.BuildingName = floor.Building.Name;
            return result;
        }
        //BuildingID
        public async Task<List<ReadFloorDTO>> GetFloorsOnBuilding(EntityDTO input)
        {
            var floors = await _repository
                .GetAll()
                .Include(x => x.Building)
                .Where(x => x.Building.Id == input.Id)
                .ToListAsync();
            List<ReadFloorDTO> result = new List<ReadFloorDTO>();
            foreach (var item in floors)
            {
                ReadFloorDTO dto = new ReadFloorDTO();
                dto = _mapper.Map<ReadFloorDTO>(item);
                dto.BuildingName = item.Building.Name;

                result.Add(dto);
            }
            return result;
        }

        public async Task UpdateFloor(UpdateFloorDTO input)
        {
            var floor = _mapper.Map<Floor>(input);
            if(Guid.Empty != input.BuildingId)
                floor.Building = await _buildingRepository.GetById(input.BuildingId);
            await _repository.Update(floor.Id,floor);
        }
    }
}
