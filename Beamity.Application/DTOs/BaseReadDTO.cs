using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs
{
    public abstract class BaseReadDTO:BaseDTO<Guid>
    {
        public DateTime CreatedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
