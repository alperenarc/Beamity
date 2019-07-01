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
    public class FloorRepository : BaseRepository<Floor>,IFloorRepository
    {
        public FloorRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public async Task<List<Floor>> GetFloorsWithBuildingId( Guid buildingId )
        {
            return await Table.Where(p => p.Building.Id == buildingId).ToListAsync();
        }
    }
}
