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

        //public Relation GetRelationWithBeaconId(Guid beaconId) {

        //    var reletaion = Table.FirstOrDefault(p => p.BeaconId == beaconId).to;

        //}
    }
}
