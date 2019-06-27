﻿using System;
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

        /*Foreign Keys*/
        public Nullable<int> RoomId { get; set; }
        public Room Room { get; set; }
    }
}