﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.UserDTOs
{
    public class UpdateUserDTO : BaseDTO<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
