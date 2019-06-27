using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Core.Models
{
    public class Building :EntityBase
    {
        [Required(ErrorMessage ="Please enter your build name")]
        public string Name { get; set; }

        public Location Location { get; set; }
        public ICollection<Floor> Floors { get; set; }
    }
}
