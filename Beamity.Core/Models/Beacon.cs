using Beamity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Core.Models
{
    public class Beacon : EntityBase
    {
        [Required(ErrorMessage ="Please enter your beacon name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your UUID!")]
        public string UUID { get; set; }
        [Required(ErrorMessage = "Please enter your Major!")]
        public int Major { get; set; }
        [Required(ErrorMessage = "Please enter Minor!")]
        public int Minor { get; set; }
        public Location Location { get; set; }
    }
}
