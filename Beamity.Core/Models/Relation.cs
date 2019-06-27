using System;

namespace Beamity.Core.Models
{
    public class Relation : EntityBase
    {
        public int ArtifactId { get; set; }
        public Artifact Artifact { get; set; }

        public int ContentId { get; set; }
        public Content Content { get; set; }

        public Nullable<int> BeaconId { get; set; }
        public Beacon Beacon { get; set; }
    }
}
