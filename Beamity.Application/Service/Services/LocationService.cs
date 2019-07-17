using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly IBaseGenericRepository<Location> _repository;
        private readonly IBaseGenericRepository<Project> _projectRepository;
        private readonly IBaseGenericRepository<User> _userRepository;

        private readonly IMapper _mapper;
        public LocationService(IBaseGenericRepository<Location> repository,
                                IBaseGenericRepository<Project> projectRepository,
                                IBaseGenericRepository<User> userRepository,
                                IMapper mapper)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _repository = repository;
        }

        public async Task CreateLocation(CreateLocationDTO input)
        {
            var location = _mapper.Map<Location>(input);
            location.Project = await _projectRepository.GetById(input.ProjectId);
            location.User = await _userRepository.GetById(input.UserId);
            await _repository.Create(location);
        }

        public async Task DeleteLocation(DeleteLocationDTO input)
        {
           await _repository.Delete(input.Id);
        }
        //ProjectID
        //GetAll locations on System
        public async Task<List<ReadLocationDTO>> GetAllLocation(EntityDTO input)
        {
            var locations = await _repository
                .GetAll()
                .Include(a => a.Project)
                .Where(x => x.IsActive && x.Project.Id == input.Id)
                .ToListAsync();
            List<ReadLocationDTO> result = new List<ReadLocationDTO>();
            foreach (var item in locations)
            {
                ReadLocationDTO dto = new ReadLocationDTO();

                dto = _mapper.Map<ReadLocationDTO>(item);
                dto.ProjectName = item.Project.Name;

                result.Add(dto);
            }
            return result;
        }
        //Get all users Location
        public async Task<List<ReadLocationDTO>> GetAllLocationWithUser(EntityDTO input)
        {
            var locations = await _repository
                .GetAll()
                .Include(a => a.User)
                .Include( x => x .Project)
                .Where(x => x.IsActive && x.User.Id == input.Id)
                .ToListAsync();
            List<ReadLocationDTO> result = new List<ReadLocationDTO>();
            foreach (var item in locations)
            {
                ReadLocationDTO dto = new ReadLocationDTO();

                dto = _mapper.Map<ReadLocationDTO>(item);
                dto.ProjectName = item.Project.Name;

                result.Add(dto);
            }
            return result;
        }

        public async Task<ReadLocationDTO> GetLocation(EntityDTO input)
        {
            var location = await _repository
                .GetAll()
                .Include(x => x.Project)
                .FirstOrDefaultAsync(a => a.IsActive && a.Id == input.Id);
            var result = _mapper.Map<ReadLocationDTO>(location);
            result.ProjectName = location.Project.Name;
            return result;
        }

        public async Task UpdateLocation(UpdateLocationDTO input)
        {
            var location = _mapper.Map<Location>(input);
            location.Project = await _projectRepository.GetById(input.ProjectId);
            await _repository.Update(location.Id,location);
        }
    }
}
