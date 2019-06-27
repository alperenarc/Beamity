using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class ContentRepository : BaseRepository<Content>
    {
        public ContentRepository(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
