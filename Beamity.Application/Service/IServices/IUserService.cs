using Beamity.Application.DTOs.UserDTOs;
using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IUserService
    {
        Task Register(CreateUserDTO input);
        Task<User> Login(LoginUserDTO input);
        Task UpdateProfile(UpdateUserDTO input);
        User ConfirmEmail(string confirmCode);
    }
}
