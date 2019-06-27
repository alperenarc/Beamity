using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beamity.Core.Models
{
    public class Room : EntityBase
    {
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(47)]
        public string Name { get; set; }


        /*Foreign Keys*/
        public virtual Floor Floor { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }

    }
}