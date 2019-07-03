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
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public async Task<List<Room>> GetRoomsWithFloorId( Guid floorId )
        {
            return await Table.Where(p => p.Floor.Id == floorId).ToListAsync();
        }
        public override List<Room> GetAll()
        {
            return Table.Where(p => p.IsActive == true).Include(p => p.Floor).ToList();
        }
    }
}
