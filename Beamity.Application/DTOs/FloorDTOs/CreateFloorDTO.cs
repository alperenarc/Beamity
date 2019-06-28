using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Application.DTOs.FloorDTOs
{
    public class CreateFloorDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Building BuildingId { get; set; }
    }
}
