using System.ComponentModel.DataAnnotations;

namespace Beamity.Core.Models
{
    public class Room
    {
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(47)]
        public string Name { get; set; }

        /*Froign Keys*/
        public int FloorId { get; set; }
        public Floor Floor{ get; set; }
    }
}