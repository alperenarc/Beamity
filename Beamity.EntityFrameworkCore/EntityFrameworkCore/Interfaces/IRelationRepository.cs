using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IRelationRepository
    {
        Relation GetRelationWithBeaconId(Guid beaconId, string proximity);
        List<Relation> GetAll();
        Relation GetById(Guid id);
        Relation Create(Relation model);
        void Update(Relation model);
        void Delete(Relation model);
        void Delete(Guid id);
    }
}
