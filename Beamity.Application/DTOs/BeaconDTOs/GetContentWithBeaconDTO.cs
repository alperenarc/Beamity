using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.BeaconDTOs
{
    public class GetContentWithBeaconDTO
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public string UUID { get; set; }
        public string Proximity { get; set; }

    }
}