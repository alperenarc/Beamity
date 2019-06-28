using Beamity.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IUserService
    {
        void Register(CreateUserDTO input);
        Task Login(LoginUserDTO input);
        void UpdateProfile(UpdateUserDTO input);
    }
}
