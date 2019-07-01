using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetRoomsWithFloorId(Guid roomId);
        List<Room> GetAll();
        Room GetById(Guid id);
        Room Create(Room model);
        void Update(Room model);
        void Delete(Room model);
        void Delete(Guid id);
    }
}
