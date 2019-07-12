using Beamity.Application.DTOs;
using Beamity.Application.DTOs.FloorDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IFloorService
    {
        Task<List<ReadFloorDTO>> GetAllFloor(EntityDTO input);
        Task CreateFloor(CreateFloorDTO input);
        Task UpdateFloor(UpdateFloorDTO input);
        Task DeleteFloor(DeleteFloorDTO input);
        Task<ReadFloorDTO> GetFloor(EntityDTO input);
        Task<List<ReadFloorDTO>> GetFloorsOnBuilding(EntityDTO input);
    }
}
