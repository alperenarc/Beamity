using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository(BeamityDbContext context) : base(context)
        {
        }
    }
}
