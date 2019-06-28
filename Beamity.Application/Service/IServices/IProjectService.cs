using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ProjectDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IProjectService
    {
        void CreateProcet(CreateProjectDTO input);
        void UpdateProject(UpdateProjectDTO input);
        void DeleteProject(DeleteProjectDTO input);
        List<ReadProjectDTO> GetAllProject();
        ReadProjectDTO GetProject(EntityDTO input);
    }
}
