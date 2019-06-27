using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Core.Models
{
    public class Floor : EntityBase
    {
        [Required(ErrorMessage = "Please enter your floor name")]
        public string Name { get; set; }

        public Building Building { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
