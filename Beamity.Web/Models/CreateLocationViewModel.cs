using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.Web.Models
{
    public class CreateLocationViewModel
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public IFormFile Photo { get; set; }

        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}
