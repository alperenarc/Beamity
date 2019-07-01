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
        List<ReadRelationDTO> GetAllRelations();
        ReadRelationDTO GetRelation(EntityDTO input);
        //Beacon Id den relation ı , oradan da  contenti bulur ve döndürür
        ReadContentDTO GetContentWithBeacon(GetContentWithBeaconDTO input);
        void CreateRelation(CreateRelationDTO input);
        void DeleteRelationDTO(DeleteRelationDTO input);
        void UpdateRelation(UpdateRelationDTO input);
    }
}
