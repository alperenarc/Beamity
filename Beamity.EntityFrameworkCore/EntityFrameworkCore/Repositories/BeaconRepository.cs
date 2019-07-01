using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class BeaconRepository : BaseRepository<Beacon>, IBeaconRepository
    {
        public BeaconRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public Beacon GetBeaconWithIds(string uUID,int major,int minor)
        {
            return Table.FirstOrDefault(p => p.Major == major && p.Minor == minor && p.UUID == uUID);
        }
    }
}
