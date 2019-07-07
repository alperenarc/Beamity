using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.Web.Models.AzureViewModels
{
    public class FileInputModel
    {
        public string Folder { get; set; }
        public IFormFile File { get; set; }

       
    }
}
