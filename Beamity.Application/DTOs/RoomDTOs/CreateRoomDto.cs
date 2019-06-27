using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Application.DTOs.RoomDTOs
{
    class CreateRoomDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid FloorId { get; set; }

    }
}
