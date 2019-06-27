using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Core.Models
{
    public class Location: EntityBase
    {
        [Required(ErrorMessage ="Please enter your locaiton name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Latitude")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Please enter your Longitude")]
        public string Longitude { get; set; }

        public Project Project { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}
