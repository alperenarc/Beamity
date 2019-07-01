using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IBeaconRepository
    {
        Beacon GetBeaconWithIds(string uUID, int major, int minor);     
        List<Beacon> GetAll();
        Beacon GetById(Guid id);
        Beacon Create(Beacon model);
        void Update(Beacon model);
        void Delete(Beacon model);
        void Delete(Guid id);
    }
}
