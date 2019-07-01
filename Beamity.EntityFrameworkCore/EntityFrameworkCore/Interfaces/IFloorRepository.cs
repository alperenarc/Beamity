using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    interface IFloorRepository
    {
        Task<List<Floor>> GetFloorsWithBuildingId(Guid buildingId);
        List<Floor> GetAll();
        Floor GetById(Guid id);
        Floor Create(Floor model);
        void Update(Floor model);
        void Delete(Floor model);
        void Delete(Guid id);
    }
}
