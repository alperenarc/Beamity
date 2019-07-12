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
        Task CreateProject(CreateProjectDTO input);
        Task UpdateProject(UpdateProjectDTO input);
        Task DeleteProject(DeleteProjectDTO input);
        Task<List<ReadProjectDTO>> GetAllProject();
        Task<ReadProjectDTO> GetProject(EntityDTO input);
    }
}
