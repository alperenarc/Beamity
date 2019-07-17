using Beamity.Application.DTOs;
using Beamity.Application.DTOs.AnalyticDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IAnalyticService
    {
        //ArtifactId
        //Task GetArtifactVisitorCount(EntityDTO input);
        //ContentId
        //Task GetContentOpenedCount(EntityDTO input);
        Task<List<ReadAnalyticDTO>> GetAllBeaconsWithHours();
        Task CreateAnalytic(CreateAnalyticDTO input);
    }
}
