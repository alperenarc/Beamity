using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Application.DTOs.RoomDTOs
{
    public class CreateRoomDTO
    {
        public string Name { get; set; }
        public Guid BeaconId { get; set; }
        public Guid FloorId { get; set; }

    }
}
