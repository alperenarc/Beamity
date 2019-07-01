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
        List<ReadContentDTO> GetHomePageContents();
        List<ReadContentDTO> GetAllContents();
        ReadContentDTO GetContent(EntityDTO input);
        void CrateContent(CreateContentDTO input);
        void UpdateContent(UpdateContentDTO input);
        void DeleteContent(DeleteContentDTO input);

    }
}
