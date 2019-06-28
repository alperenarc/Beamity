using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.Service.IServices;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly RoomRepository _repository;
        public RoomService(RoomRepository repository)
        {
            _repository = repository;
        }

        public void CreateRoom(CreateRoomDTO input)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoom(DeleteRoomDTO input)
        {
            throw new NotImplementedException();
        }

        public List<ReadRoomDTO> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public ReadRoomDTO GetRoom(EntityDTO input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoom(UpdateRoomDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
