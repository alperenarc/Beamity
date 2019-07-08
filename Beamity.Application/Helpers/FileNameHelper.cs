using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Helpers
{
    public class FileNameHelper
    {
        public static string CreateFileName(string extension)
        {
            return Guid.NewGuid().ToString().Replace("-", "") + extension;
        }
    }

}
