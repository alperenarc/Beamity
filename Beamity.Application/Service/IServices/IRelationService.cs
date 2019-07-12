using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IRelationService
    {
       Task<List<ReadRelationDTO>> GetAllRelations(EntityDTO input);
        Task<ReadRelationDTO> GetRelation(EntityDTO input);
        //Beacon Id den relation ı , oradan da  contenti bulur ve döndürür
        Task<ReadContentDTO> GetContentWithBeacon(GetContentWithBeaconDTO input);
        Task CreateRelation(CreateRelationDTO input);
        Task DeleteRelationDTO(DeleteRelationDTO input);
        Task UpdateRelation(UpdateRelationDTO input);
    }
}
