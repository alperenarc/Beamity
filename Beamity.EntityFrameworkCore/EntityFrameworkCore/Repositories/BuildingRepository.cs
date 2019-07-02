using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class BuildingRepository : BaseRepository<Building>
    {
        public BuildingRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public async Task<List<Building>> GetBuildingWithLocationId(Guid locaitonId)
        {

            return await Table.Where(p => p.Location.Id == locaitonId).ToListAsync();
        }
    }
}
