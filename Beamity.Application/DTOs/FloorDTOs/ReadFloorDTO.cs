using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.FloorDTOs
{
    public class ReadFloorDTO : BaseReadDTO
    {
        public string Name { get; set; }
        public string BuildingName { get; set; }
    }
}
