﻿using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class BeaconRepository : BaseRepository<Beacon>
    {
        public BeaconRepository(BeamityDbContext context)
            : base(context)
        {
        }
        
        public Beacon GetBeaconWithName(string UUID,int minor,int major)

        {
            return Table.FirstOrDefault(p => p.UUID == UUID & p.Minor == minor & p.Major == major);
        } 
    }
}
