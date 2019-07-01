using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(BeamityDbContext context)
            : base(context)
        {
        }
        public async Task<bool> IsUserExist(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
