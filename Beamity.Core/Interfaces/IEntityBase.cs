using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Beamity.Core.Interfaces
{
    public interface IEntityBase
    {
        
        Guid ID { get; set; }
        bool IsActive { get; set; }
        DateTime CreatedTime { get; set; }

    }
}
