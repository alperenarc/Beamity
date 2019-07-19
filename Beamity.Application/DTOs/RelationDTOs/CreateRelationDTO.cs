using System;

namespace Beamity.Application.DTOs.RelationDTO
{
    public class CreateRelationDTO
    {
        public Nullable<Guid> ArtifactId { get; set; }
        public Guid ContentId { get; set; }
        public Guid BeaconId { get; set; }
        public Guid LocationId { get; set; }
        public string Proximity { get; set; }

    }
}
