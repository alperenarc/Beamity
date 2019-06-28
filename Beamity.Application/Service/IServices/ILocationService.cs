using Beamity.Application.DTOs;
using Beamity.Application.DTOs.LocationDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface ILocationService
    {
        void CreateLocation(CreateLocationDTO input);
        Task UpdateFloor(UpdateLocationDTO input);
        void DeleteFloor(DeleteLocationDTO input);
        List<ReadLocationDTO> GetAllLocation();
        ReadLocationDTO GetLocation(EntityDTO input);
    }
}
