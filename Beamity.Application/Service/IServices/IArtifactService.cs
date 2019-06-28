using Beamity.Application.DTOs.ArtifactDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IArtifactService
    {
        List<ReadArtifactDTO> GetAllArtifacts();
        void CreateArtifact(CreateArtifactDTO input);
        Task UpdateArtifact(UpdateArtifactDTO input);
        void DeleteArtifact(DeleteArtifactDTO input);
    }
}
