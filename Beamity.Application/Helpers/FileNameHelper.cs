using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Helpers
{
    public class FileNameHelper
    {
        public static string CreateFileName()
        {
            return Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
        }
    }

}
