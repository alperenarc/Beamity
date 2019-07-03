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
        public override List<Artifact> GetAll()
        {
            return Table.Where(p => p.IsActive == true).Include(p => p.Room).
                Include(p => p.Room.Floor).Include(p => p.Room.Floor.Building).ToList();
        }
    }
}
