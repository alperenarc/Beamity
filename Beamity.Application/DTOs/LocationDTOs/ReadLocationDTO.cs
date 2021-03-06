﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.LocationDTOs
{
    public class ReadLocationDTO : BaseReadDTO
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ProjectName { get; set; }
        public string PhotoURL { get; set; }
    }
}
