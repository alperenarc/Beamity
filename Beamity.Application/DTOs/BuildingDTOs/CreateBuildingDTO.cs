using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.BuildingDTOs
{
    public class CreateBuildingDTO
    {
        public string Name { get; set; }

        public Guid LocationId { get; set; }
    }
}
