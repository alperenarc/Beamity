using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IBuildingRepository
    {
        Task<List<Building>> GetBuildingWithLocationId(Guid locaitonId);
        List<Building> GetAll();
        Building GetById(Guid id);
        Building Create(Building model);
        void Update(Building model);
        void Delete(Building model);
        void Delete(Guid id);
    }
}
