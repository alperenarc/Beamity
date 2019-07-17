using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        public Guid LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}