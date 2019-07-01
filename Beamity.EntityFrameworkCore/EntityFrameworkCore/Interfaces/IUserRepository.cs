using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IUserRepository
    {
        User getUserForLogin(string email);
        List<User> GetAll();
        User GetById(Guid id);
        User Create(User model);
        void Update(User model);
        void Delete(User model);
        void Delete(Guid id);
    }
}
