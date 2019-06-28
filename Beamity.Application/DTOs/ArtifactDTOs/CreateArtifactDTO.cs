using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beamity.Application.DTOs.ArtifactDTOs
{
    public class CreateArtifactDTO
    {
        public string Name { get; set; }
        public string MainImageURL { get; set; }
        public Guid RoomId { get; set; }
    }
}
