using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class BuildingRepository : BaseRepository<Building>
    {
        public BuildingRepository(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
