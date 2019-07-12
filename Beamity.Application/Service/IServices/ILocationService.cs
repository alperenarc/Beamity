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
        Task CreateLocation(CreateLocationDTO input);
        Task UpdateLocation(UpdateLocationDTO input);
        Task DeleteLocation(DeleteLocationDTO input);
        Task <List<ReadLocationDTO>> GetAllLocation(EntityDTO input);
        Task<ReadLocationDTO> GetLocation(EntityDTO input);
    }
}
