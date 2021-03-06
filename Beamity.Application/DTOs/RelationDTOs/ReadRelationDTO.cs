﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.RelationDTO
{
    public class ReadRelationDTO :BaseReadDTO
    {
        public string ArtifacName { get; set; }
        public string ContentName{ get; set; }
        public string BeaconName{ get; set; }
        public string Proximity{ get; set; }
    }
}
