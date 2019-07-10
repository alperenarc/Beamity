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
        void UpdateProject(UpdateProjectDTO input);
        void DeleteProject(DeleteProjectDTO input);
        Task<List<ReadProjectDTO>> GetAllProject(string UserId);
        ReadProjectDTO GetProject(EntityDTO input);
    }
}
