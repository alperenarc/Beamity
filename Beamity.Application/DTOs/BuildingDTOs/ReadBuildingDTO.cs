using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.BuildingDTOs
{
    public class ReadBuildingDTO : BaseReadDTO
    {
        public string Name { get; set; }
        public string LocationName { get; set; }
    }
}
