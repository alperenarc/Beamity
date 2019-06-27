
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Core.Models
{
    public class User: EntityBase
    {
        [Required(ErrorMessage ="Please enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Token { get; set; }
        public string Hash { get; set; }
    }
}
