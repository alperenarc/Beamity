using System;

namespace Beamity.Core.Models
{
    public class Relation : EntityBase
    {
        public Artifact Artifact { get; set; }

        public Content Content { get; set; }

        public Beacon Beacon { get; set; }

        public Proximity Proximity { get; set; } = Proximity.Unknown;
        public Project Project { get; set; }
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
