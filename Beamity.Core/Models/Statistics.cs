using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Beamity.Core.Models
{
    public class Statistics : EntityBase
    {
        public Guid BeaconId { get; set; }
        [ForeignKey("BeaconId")]
        public Beacon Beacon { get; set; }
    }
}
