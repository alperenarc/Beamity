using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class LocationRepository : BaseRepository<Location>
    {
        public LocationRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public override List<Location> GetAll()
        {
            return Table.Where(p => p.IsActive == true).Include(p => p.Project).ToList();
        }
    }
}
