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
        List<ReadFloorDTO> GetAllFloor();
        void CreateFloor(CreateFloorDTO input);
        void UpdateFloor(UpdateFloorDTO input);
        void DeleteFloor(DeleteFloorDTO input);
        ReadFloorDTO GetFloor(EntityDTO input);
    }
}
