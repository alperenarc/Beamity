using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class ProjectRepository : BaseRepository<Project>,IProjectRepository
    {
        public ProjectRepository(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
