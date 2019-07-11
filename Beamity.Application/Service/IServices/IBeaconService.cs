using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IBeaconService
    {
        Task CreateBeacon(CreateBeaconDTO input);
        Task UpdateBeacon(UpdateBeaconDTO input);
        Task DeleteBeacon(DeleteBeaconDTO input);
        Task<List<ReadBeaconDTO>> GetAllBeacons(EntityDTO input);
        Task<ReadBeaconDTO> GetBeacon(EntityDTO input);
    }
}
