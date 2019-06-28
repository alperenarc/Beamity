using AutoMapper;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task Login(LoginUserDTO input)
        {
            //Token verilecek//
            throw new NotImplementedException();
        }

        public void Register(CreateUserDTO input)
        {
            var user = _mapper.Map<User>(input);
            //Şifre hash edilip user a atılacak//
            _userRepository.Create(user);
        }

        public void UpdateProfile(UpdateUserDTO input)
        {
            var user = _mapper.Map<User>(input);
            _userRepository.Update(user);
        }
    }
}
