using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly RoomRepository _roomRepository;
        private readonly FloorRepository _floorRepository;

        private readonly IMapper _mapper;
        public RoomService(RoomRepository roomRepository, FloorRepository floorRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public void CreateRoom(CreateRoomDTO input)
        {
            var room = _mapper.Map<Room>(input);
            room.Floor = _floorRepository.GetById(input.FloorId);
            _roomRepository.Create(room);
        }

        public void DeleteRoom(DeleteRoomDTO input)
        {
            _roomRepository.Delete(input.Id);
        }

        public List<ReadRoomDTO> GetAllRooms()
        {
            var rooms = _roomRepository.GetAll();
            List<ReadRoomDTO> result = _mapper.Map <List<ReadRoomDTO>>(rooms);
            for (int i = 0; i < rooms.Count; i++)
            {
                result[i].FloorName = rooms[i].Floor.Name;
            }
            return result;
        }

        public ReadRoomDTO GetRoom(EntityDTO input)
        {
            var room = _roomRepository.GetById(input.Id);
            var result = _mapper.Map<ReadRoomDTO>(room);
            result.FloorName = room.Floor.Name;
            return result;
        }

        public async Task<List<ReadRoomDTO>> GetRoomsOnFloor(EntityDTO input)
        {
            var rooms = await _roomRepository.GetRoomsWithFloorId(input.Id);
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

        public void UpdateRoom(UpdateRoomDTO input)
        {
            var room = _mapper.Map<Room>(input);
            _roomRepository.Update(room);
        }
    }
}
