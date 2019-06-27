using Beamity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Core.Models
{
    public class EntityBase : IEntityBase
    {
        public Guid ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }

        /*
         * Constructer are to automatically assign ID and get the current time.
         * 
         */
        public EntityBase()
        {
            Guid ANewID = new Guid();
            ID = ANewID;
            IsActive = true;
            CreatedTime = DateTime.Now;
        }
    }
}
