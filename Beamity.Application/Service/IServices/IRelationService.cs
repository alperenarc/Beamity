using Beamity.Application.DTOs;
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
        ReadRelationDTO GetRealtion(EntityDTO input);
        ReadRelationDTO GetRelationWithBeacon(EntityDTO input);
        void Createelation(CreateRelationDTO input);
        void DeleteRelationDTO(DeleteRelationDTO input);
        Task UpdateRelation(UpdateRelationDTO input);
    }
}
