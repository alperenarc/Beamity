using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Beamity.Core.Models
{
    public class Role : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

    }
    public enum ERole
    {
        Common = 1,
        Administrator = 2
    }
}