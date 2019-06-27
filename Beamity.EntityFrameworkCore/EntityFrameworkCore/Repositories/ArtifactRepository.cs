using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class ArtifactRepository : BaseRepository<Artifact>
    {
        public ArtifactRepository(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
