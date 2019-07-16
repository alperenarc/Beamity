using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.Web.Models
{
    public class UpdateContentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile MainImage { get; set; }
        public IFormFile Video { get; set; }
        public IFormFile SlideImage { get; set; }
        public IFormFile Audio { get; set; }
        public string Text { get; set; }
        public bool IsHomePage { get; set; }
        public bool IsCampaign { get; set; }
        public Guid LocationId { get; set; }
    }
}
