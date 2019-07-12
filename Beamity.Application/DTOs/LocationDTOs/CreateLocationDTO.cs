using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.LocationDTOs
{
    public class CreateLocationDTO
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId{ get; set; }
    }
}
