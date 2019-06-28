using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.ArtifactDTOs
{
    public class ReadArtifactDTO : BaseDTO<Guid>
    {
        public string Name { get; set; }
    }
}
