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
        void CrateContent(CreateContentDTO input);
        void UpdateContent(UpdateContentDTO input);
        void DeleteContent(DeleteContentDTO input);

    }
}
