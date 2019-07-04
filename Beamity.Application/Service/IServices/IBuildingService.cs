using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BuildingDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IBuildingService
    {
        Task<IList<ReadBuildingDTO>> GetAllBuildings();
        Task<ReadBuildingDTO> GetBuildingAsync(EntityDTO input);
        Task CreateBuildingAsync(CreateBuildingDTO input);
        Task DeleteBuilding(DeleteBuildingDTO input);
        Task UpdateBuilding (UpdateBuildingDTO input);
        Task<IList<ReadBuildingDTO>> GetBuildingsAtLocation(EntityDTO input);

    }
}
