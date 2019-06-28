using Beamity.Application.DTOs.UserDTOs;
using Beamity.Application.Service.IServices;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public Task Login(LoginUserDTO input)
        {
            throw new NotImplementedException();
        }

        public void Register(CreateUserDTO input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfile(UpdateUserDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
