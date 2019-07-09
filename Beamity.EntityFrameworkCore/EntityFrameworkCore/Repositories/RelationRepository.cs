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
    public class RelationRepository : BaseRepository<Relation>
    {
        public RelationRepository(BeamityDbContext context)
            : base(context)
        {
        }
        // Get Relation With Becon ID

        public Relation GetRelationWithBeaconId(Guid beaconId, string proximity)
        {
            Proximity prox = (Proximity)Enum.Parse(typeof(Proximity), proximity, true);
            var GetRelation = Table.Where(p => p.Beacon.Id == beaconId && p.Proximity == prox)
                .Include(p => p.Content)
                .Include(p => p.Artifact)
                .FirstOrDefault();
            return GetRelation;
        }
        public override List<Relation> GetAll()
        {

            return Table.Where(x => x.IsActive == true)
                 .Include(x => x.Artifact)
                 .Include(x => x.Beacon)
                 .Include(x => x.Content).ToList();
        }
    }
}
