using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IContentRepository
    {
        List<Content> GetHomeContent();
        List<Content> GetAll();
        Content GetById(Guid id);
        Content Create(Content model);
        void Update(Content model);
        void Delete(Content model);
        void Delete(Guid id);
    }
}
