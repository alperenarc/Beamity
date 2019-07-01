using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> GetAll();
        Project GetById(Guid id);
        Project Create(Project model);
        void Update(Project model);
        void Delete(Project model);
        void Delete(Guid id);
    }
}
