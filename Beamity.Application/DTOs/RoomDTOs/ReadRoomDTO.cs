using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.RoomDTOs
{
    public class ReadRoomDTO : BaseReadDTO
    {
        public string Name { get; set; }
        public string FloorName { get; set; }
    }
}
