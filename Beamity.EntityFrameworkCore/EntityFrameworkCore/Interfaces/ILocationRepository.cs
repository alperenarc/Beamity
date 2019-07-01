using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        Location GetById(Guid id);
        Location Create(Location model);
        void Update(Location model);
        void Delete(Location model);
        void Delete(Guid id);
    }
}
