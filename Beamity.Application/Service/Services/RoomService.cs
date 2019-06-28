using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly RoomRepository _repository;
        public RoomService(RoomRepository repository)
        {
            _repository = repository;
        }
    }
}
