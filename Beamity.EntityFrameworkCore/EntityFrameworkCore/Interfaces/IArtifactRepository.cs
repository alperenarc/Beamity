using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IArtifactRepository
    {
        Task<List<Artifact>> GetArtifactsWithRoomId(Guid roomId);
        List<Artifact> GetAll();
        Artifact GetById(Guid id);
        Artifact Create(Artifact model);
        void Update(Artifact model);
        void Delete(Artifact model);
        void Delete(Guid id);
    }
}
