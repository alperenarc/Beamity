using System;

namespace Beamity.Core.Models
{
    public class Relation : EntityBase
    {
        public Artifact Artifact { get; set; }

        public Content Content { get; set; }

        public Beacon Beacon { get; set; }
    }
}
