using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
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
            var GetRelation = Table.Where(p => p.Beacon.Id == beaconId && p.Proximity == prox).FirstOrDefault();
            return GetRelation;
        }
    }
}
