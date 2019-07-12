using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RoomDTOs;
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
    public class RoomService : IRoomService
    {
        private readonly IBaseGenericRepository<Room> _roomRepository;
        private readonly IBaseGenericRepository<Floor> _floorRepository;
        private readonly IBaseGenericRepository<Beacon> _beaconRepository;
        private readonly IMapper _mapper;
        public RoomService(IBaseGenericRepository<Beacon> beaconRepository, IBaseGenericRepository<Room> roomRepository, IBaseGenericRepository<Floor> floorRepository, IMapper mapper)
        {
            _beaconRepository = beaconRepository;
            _roomRepository = roomRepository;
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task CreateRoom(CreateRoomDTO input)
        {
            var room = _mapper.Map<Room>(input);
            room.Floor = await _floorRepository.GetById(input.FloorId);

            if (input.BeaconId != Guid.Empty)
            {
                room.Beacon = await _beaconRepository.GetById(input.BeaconId);
            }
            await _roomRepository.Create(room);
        }

        public async Task DeleteRoom(DeleteRoomDTO input)
        {
            await _roomRepository.Delete(input.Id);
        }

        public async Task<List<ReadRoomDTO>> GetAllRooms(EntityDTO input)
        {
            var rooms = await _roomRepository.GetAll()
                .Include(x=>x.Floor)
                .ThenInclude(x=>x.Building)
                .ThenInclude(x=>x.Location)
                .Where(x=>x.IsActive == true && x.Floor.Building.Location.Id == input.Id)
                .ToListAsync();

            List<ReadRoomDTO> result = _mapper.Map<List<ReadRoomDTO>>(rooms);
            for (int i = 0; i < rooms.Count; i++)
            {
                result[i].FloorName = rooms[i].Floor.Name;
            }
            return result;
        }

        public async Task<ReadRoomDTO> GetRoom(EntityDTO input)
        {
            var room = await _roomRepository.GetById(input.Id);
            var result =_mapper.Map<ReadRoomDTO>(room);
            result.FloorName = room.Floor.Name;
            return result;
        }

        public async Task<List<ReadRoomDTO>> GetRoomsOnFloor(EntityDTO input)
        {
            // Input.Id = EntityDTO is a floor ID
            
            var rooms = await _roomRepository.GetAll()
                .Include(x=>x.Floor)
                .Where(x=>x.Floor.Id == input.Id)
                .ToListAsync();
            
            List<ReadRoomDTO> result = new List<ReadRoomDTO>();
            foreach (var item in rooms)
            {
                ReadRoomDTO dto = new ReadRoomDTO();
                dto = _mapper.Map<ReadRoomDTO>(item);
                dto.FloorName = item.Floor.Name;

                result.Add(dto);
            }
            return result;
        }

        public async Task UpdateRoom(UpdateRoomDTO input)
        {
            var room = _mapper.Map<Room>(input);
            room.Floor = await _floorRepository.GetById(input.FloorId);
            await _roomRepository.Update(input.Id,room);
        }
    }
}
