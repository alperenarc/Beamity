using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beamity.Core.Models
{
    public class Relation : EntityBase
    {
        public Guid ArtifactId { get; set; }
        [ForeignKey("ArtifactId")]
        public Artifact Artifact { get; set; }
        public Guid ContentId { get; set; }
        [ForeignKey("ContentId")]
        public Content Content { get; set; }
        public Guid BeaconId { get; set; }
        [ForeignKey("BeaconId")]
        public Beacon Beacon { get; set; }

        public Proximity Proximity { get; set; } = Proximity.Unknown;
        public Guid LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
    public enum Proximity
    {
        Unknown,
        Far,
        Near,
        Immediate,
        All
    }
}
