using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.ProjectDTOs
{
    public class UpdateProjectDTO:BaseDTO<Guid>
    {
        public string Name { get; set; }
    }
}
