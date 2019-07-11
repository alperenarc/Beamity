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
        Task<List<ReadBuildingDTO>> GetAllBuildings( EntityDTO input);
        Task<ReadBuildingDTO> GetBuilding(EntityDTO input);
        Task CreateBuilding(CreateBuildingDTO input);
        Task DeleteBuilding(DeleteBuildingDTO input);
        Task UpdateBuilding (UpdateBuildingDTO input);
        Task<List<ReadBuildingDTO>> GetBuildingsAtLocation(EntityDTO input);

    }
}
