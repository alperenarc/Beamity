using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RoomDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IRoomService
    {
        List<ReadRoomDTO> GetAllRooms();
        ReadRoomDTO GetRoom(EntityDTO input);
        void CreateRoom(CreateRoomDTO input);
        Task UpdateRoom(UpdateRoomDTO input);
        void DeleteRoom(DeleteRoomDTO input);
    }
}
