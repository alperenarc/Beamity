using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.RelationDTO
{
    public class UpdateRelationDTO : BaseDTO<Guid>
    {
        public Guid ArtifactId { get; set; }
        public Guid ContentId { get; set; }
        public Guid BeaconId { get; set; }
        public string Proximity { get; set; }
    }
}
