using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs
{
    public abstract class BaseReadDTO
    {
        public DateTime CreatedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
