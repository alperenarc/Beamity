using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.RelationDTO
{
    public class CreateRelationDTO
    {
        public Guid ArtifactId { get; set; }
        public Guid ContentId { get; set; }
        public Guid BeaconId { get; set; }
        public Proximity Proximity { get; set; }

    }
}
