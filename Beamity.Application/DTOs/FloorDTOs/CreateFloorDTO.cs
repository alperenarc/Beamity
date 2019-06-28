using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Application.DTOs.FloorDTOs
{
    public class CreateFloorDTO
    {
        public string Name { get; set; }
        public Guid BuildingId { get; set; }
    }
}
