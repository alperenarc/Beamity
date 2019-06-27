﻿using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class ArtifactRepository : BaseRepository<Artifact>
    {
        public ArtifactRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public async Task<List<Artifact>> GetArtifactsWithRoomId( Guid roomId )
        {

            return await Table.Where(p => p.Room.Id == roomId).ToListAsync();
        }
    }
}