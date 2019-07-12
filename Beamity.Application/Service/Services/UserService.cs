using AutoMapper;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IBaseGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Login(LoginUserDTO input)
        {
            try
            {
                // get user for Login
                
                var getUser = await _userRepository.GetAll()
                    .Where(x => x.Email == input.Email)
                    .FirstOrDefaultAsync();

                // take user s hash
                string correctHash = getUser.Hash;
                // confirm password and hash
                bool confirmPassword = Helpers.PasswordHelper.ValidatePassword(input.Password, correctHash);

                // Login
                if (confirmPassword.Equals(true) && getUser.IsActive.Equals(true))
                {
                    return getUser;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Register(CreateUserDTO input)
        {
            // Password Hashing
            string hashedPassword = Helpers.PasswordHelper.HashPassword(input.Password);
            input.Password = hashedPassword;
            // IsActive of new user is default false
            input.IsActive = false;
            // Create a new GuidKey (Confirmation Key)
            string GuidKey = Guid.NewGuid().ToString();
            // Define GuidKey to Token
            input.Token = GuidKey;
            try
            {
                // Send an email for account confirmation
                Helpers.EmailHelper.SendMail(input.Email, GuidKey);
                var user = _mapper.Map<User>(input);
                user.Hash = input.Password;
                user.RoleName = ERole.Common.ToString();
                await _userRepository.Create(user);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task UpdateProfile(UpdateUserDTO input)
        {
            var user = _mapper.Map<User>(input);
            await _userRepository.Update(input.Id,user);
        }

        public async Task<User> ConfirmEmail(string ConfirmCode)
        {
            var user = await _userRepository
                .GetAll()
                .Where(x => x.Token == Convert.ToString(ConfirmCode))
                .FirstOrDefaultAsync();
            
            user.IsActive = true;
            
            var confirmuser = _mapper.Map<User>(user);
            await _userRepository.Update(user.Id, user);

            return user;
        }
    }
}