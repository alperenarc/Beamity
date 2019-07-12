using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.BeaconDTOs
{
    public class CreateBeaconDTO
    {
        public string Name { get; set; }
        public string UUID { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public Guid LocationId { get; set; }
    }
}
