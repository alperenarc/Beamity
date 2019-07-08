using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.Web.Models
{
    public class CreateArtifactViewModel
    {
        public IFormFile File{ get; set; }
        public string Name { get; set; }
        public Guid RoomId { get; set; }
    }
}
