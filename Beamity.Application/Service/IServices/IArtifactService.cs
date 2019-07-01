using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ArtifactDTOs;
using System.Collections.Generic;

namespace Beamity.Application.Service.IServices
{
    public interface IArtifactService
    {
        List<ReadArtifactDTO> GetAllArtifacts();
        void CreateArtifact(CreateArtifactDTO input);
        void UpdateArtifact(UpdateArtifactDTO input);
        void DeleteArtifact(DeleteArtifactDTO input);
        ReadArtifactDTO GetArtifact(EntityDTO input);
    }
}
