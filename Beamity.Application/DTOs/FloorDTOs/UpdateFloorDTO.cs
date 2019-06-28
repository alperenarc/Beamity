using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.FloorDTOs
{
    public class UpdateFloorDTO:BaseDTO<Guid>
    {
        public string Name { get; set; }
        public Guid BuildingId { get; set; }
    }
}
