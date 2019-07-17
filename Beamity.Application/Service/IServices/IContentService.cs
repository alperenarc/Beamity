using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ContentDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IContentService
    {
        Task<List<ReadContentDTO>> GetHomePageContents(EntityDTO input);
        Task<List<ReadContentDTO>> GetAllContents(EntityDTO input);
        Task<ReadContentDTO> GetContent(EntityDTO input);
        Task CrateContent(CreateContentDTO input);
        Task UpdateContent(UpdateContentDTO input);
        Task DeleteContent(DeleteContentDTO input);
        Task<List<ReadContentDTO>> GetAllCampaignContents(EntityDTO input);
    }
}
