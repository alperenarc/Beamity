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
        List<ReadBuildingDTO> GetAllBuildings();
        ReadBuildingDTO GetBuilding(EntityDTO input);
        void CreateBuilding(CreateBuildingDTO input);
        void DeleteBuilding(DeleteBuildingDTO input);
        void UpdateBuilding (UpdateBuildingDTO input);
        List<ReadBuildingDTO> GetBuildingsAtLocation(EntityDTO input);

    }
}
