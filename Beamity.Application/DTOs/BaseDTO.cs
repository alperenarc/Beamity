using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs
{
    public abstract class BaseDTO<T>
    {
        public T Id { get; set; }
    }
}
