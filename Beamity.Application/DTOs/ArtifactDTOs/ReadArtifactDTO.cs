using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.ArtifactDTOs
{
    public class ReadArtifactDTO : BaseReadDTO
    {
        public string Name { get; set; }
        public string MainImageURL { get; set; }

        public string RoomName { get; set; }
    }
}
