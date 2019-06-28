using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.RoomDTOs
{
    public class UpdateRoomDTO: BaseDTO<Guid>
    {
        public string Name { get; set; }
        public Guid FloorId { get; set; }
    }
}
