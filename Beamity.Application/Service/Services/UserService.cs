using AutoMapper;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using MimeKit;
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



        public bool Login(LoginUserDTO input)
        {
            try
            {
                // get user for Login
                var getUser = _userRepository.GetUserForLogin(input.Email);

                // take user s hash
                string correctHash = getUser.Hash;
                // confirm password and hash
                bool confirmPassword = Helpers.PasswordHelper.ValidatePassword(input.Password, correctHash);

                // Login
                if (confirmPassword.Equals(true) && getUser.IsActive.Equals(true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Register(CreateUserDTO input)
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

            // Send an email for account confirmation



            try
            {
                Helpers.EmailHelper.SendMail(input.Email, GuidKey);
                var user = _mapper.Map<User>(input);
                user.Hash = input.Password;
                _userRepository.Create(user, ERole.Common);
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public void UpdateProfile(UpdateUserDTO input)
        {
            var user = _mapper.Map<User>(input);
            _userRepository.Update(user);
        }


        public void ConfirmEmail(string confirmCode)
        {
            var a = _userRepository.ConfirmEmail(confirmCode);
            var user = _mapper.Map<User>(a);


        }
    }
}