using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.AnalyticDTO
{
    public class CreateAnalyticDTO
    {
        public Guid BeaconId { get; set; }
        public CreateAnalyticDTO(Guid id)
        {
            BeaconId = id;
        }
    }
}
