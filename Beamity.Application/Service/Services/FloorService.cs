using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.FloorDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
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
        private readonly FloorRepository _repository;
        private readonly BuildingRepository  _buildingRepository;
        private readonly IMapper _mapper;

        public FloorService(FloorRepository repository, BuildingRepository buildingRepository, IMapper mapper)
        {
            _mapper = mapper; // define class of mapper library
            _buildingRepository = buildingRepository;
            _repository = repository;
        }

        public void CreateFloor(CreateFloorDTO input)
        {
            var floor = _mapper.Map<Floor>(input);
            floor.Building = _buildingRepository.GetById(input.BuildingId); //firstly you must get building with building ID
            _repository.Create(floor); // and then you can push on create method
        }

        public void DeleteFloor(DeleteFloorDTO input)
        {
            _repository.Delete(input.Id);
        }

        public List<ReadFloorDTO> GetAllFloor()
        {
            var floors = _repository.GetAll();
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

        public ReadFloorDTO GetFloor(EntityDTO input)
        {
            var floor = _repository.GetById(input.Id);
            var result = _mapper.Map<ReadFloorDTO>(floor);
            result.BuildingName = floor.Building.Name;
            return result;
        }

        public async Task<List<ReadFloorDTO>> GetFloorsOnBuilding(EntityDTO input)
        {
            var floors = await _repository.GetFloorsWithBuildingId(input.Id);
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

        public void UpdateFloor(UpdateFloorDTO input)
        {
            var floor = _mapper.Map<Floor>(input);
            _repository.Update(floor);
        }
    }
}
