using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ArtifactDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IArtifactService
    {
        Task<List<ReadArtifactDTO>> GetAllArtifacts(EntityDTO input);
        Task CreateArtifact(CreateArtifactDTO input);
        Task UpdateArtifact(UpdateArtifactDTO input);
        Task DeleteArtifact(DeleteArtifactDTO input);
        Task<ReadArtifactDTO> GetArtifact(EntityDTO input);
        Task<List<ReadArtifactDTO>> GetArtifactsInRoom(EntityDTO input);
    }
}
