using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ArtifactDTOs;
using Beamity.Core.Models;
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
        void UpdateArtifact(UpdateArtifactDTO input);
        void DeleteArtifact(DeleteArtifactDTO input);
        ReadArtifactDTO GetArtifact(EntityDTO input);
    }
}
