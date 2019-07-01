using System;

namespace Beamity.Application.DTOs.RelationDTO
{
    public class CreateRelationDTO
    {
        public Guid ArtifactId { get; set; }
        public Guid ContentId { get; set; }
        public Guid BeaconId { get; set; }
        public string Proximity { get; set; }

    }
}
