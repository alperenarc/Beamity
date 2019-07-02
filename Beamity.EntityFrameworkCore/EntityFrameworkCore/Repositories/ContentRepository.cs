using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class ContentRepository : BaseRepository<Content>
    {
        public ContentRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public List<Content> GetHomeContent()
        {

            var GetContent = Table.Where(p => p.IsHomePage == true && p.IsActive == true).ToList();
            return GetContent;

        }
    }
}
