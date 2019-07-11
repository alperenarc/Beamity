using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Core.Models
{
    public class Project : EntityBase
    {
        [Required(ErrorMessage = "Please enter your project name!")]
        public string Name { get; set; }
    }
}
