using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public User GetUserForLogin(string email)
        {

            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }
        public User Create(User model, params ERole[] userRoles)
        {
            var role = _context.Roles.FirstOrDefault(r => userRoles.Any(ur => ur.ToString() == r.Name));
            try
            {
                model.RoleName = role.Name;
            }
            catch (Exception e)
            {

                throw e;
            }


            return base.Create(model);
        }
        public User ConfirmEmail(Guid ConfirmCode)
        {
            var user = _context.Users.Where(x=>x.Token == Convert.ToString(ConfirmCode)).FirstOrDefault();

            return user;
        }
    }
}
