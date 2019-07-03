using AutoMapper;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application
{
   public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, User>();
        }
    }
}
