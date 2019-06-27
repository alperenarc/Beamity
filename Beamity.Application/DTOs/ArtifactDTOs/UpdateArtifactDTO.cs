using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.ArtifactDTOs
{
    public class UpdateArtifactDTO : BaseDTO<Guid>
    {
        public string Name { get; set; }
        public string MainImageURL { get; set; }
    }
}
