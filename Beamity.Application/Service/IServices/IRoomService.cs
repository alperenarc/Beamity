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
        Task<List<ReadRoomDTO>> GetAllRooms();
        Task<ReadRoomDTO> GetRoom(EntityDTO input);
        Task CreateRoom(CreateRoomDTO input);
        Task UpdateRoom(UpdateRoomDTO input);
        Task DeleteRoom(DeleteRoomDTO input);
        Task<List<ReadRoomDTO>> GetRoomsOnFloor(EntityDTO input);
    }
}
