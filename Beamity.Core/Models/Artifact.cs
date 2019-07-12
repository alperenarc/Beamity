using System;
using System.ComponentModel.DataAnnotations;

namespace Beamity.Core.Models
{
    public class Artifact : EntityBase
    {
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(47)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Main Image Required")]
        [Display(Name = "Main Image")]
        public string MainImageURL { get; set; }

        public Guid? RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Location Location { get; set; }
    }
}