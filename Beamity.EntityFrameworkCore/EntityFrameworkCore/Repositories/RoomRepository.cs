using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
