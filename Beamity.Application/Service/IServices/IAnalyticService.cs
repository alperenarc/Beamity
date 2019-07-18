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
        Task<List<ReadAnalyticDTO>> GetAllBeaconsWithHours(EntityDTO input);
        Task CreateAnalytic(CreateAnalyticDTO input);
    }
}
