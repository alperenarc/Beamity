using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.Web.Blob
{
    public interface IBlobManager
    {
        Task<string> UploadImageAsBlob(IFormFile file);
    }
}
