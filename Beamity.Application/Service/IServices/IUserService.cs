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
        void Register(CreateUserDTO input);
        User Login(LoginUserDTO input);
        void UpdateProfile(UpdateUserDTO input);
        void ConfirmEmail(string confirmCode);
    }
}
