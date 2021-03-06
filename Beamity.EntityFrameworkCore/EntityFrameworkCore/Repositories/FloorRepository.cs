﻿using Beamity.Core.Models;
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
    public class FloorRepository : BaseRepository<Floor>
    {
        public FloorRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public async Task<List<Floor>> GetFloorsWithBuildingId( Guid buildingId )
        {
            return await Table.Where(p => p.Building.Id == buildingId).ToListAsync();
        }
        public override List<Floor> GetAll()
        {
            return Table.Where(p => p.IsActive == true).Include( p => p.Building).ToList();
        }
    }
}
