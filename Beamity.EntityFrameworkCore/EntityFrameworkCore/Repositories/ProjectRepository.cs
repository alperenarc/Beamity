using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class IBaseGenericRepostiory : BaseRepository<Project>
    {
        public IBaseGenericRepostiory(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
