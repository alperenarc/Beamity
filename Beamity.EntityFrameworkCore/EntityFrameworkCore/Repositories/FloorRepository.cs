using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class FloorRepository : BaseRepository<Floor>
    {
        public FloorRepository(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
