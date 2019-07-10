using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ArtifactDTOs;
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
    public class ArtifactService : IArtifactService
    {
        /*
         * This Class for define the Methods
         * This class contain 
         *  1.CreateArtifact
         *  2.DeleteArtifact
         *  3.GetAllArtifacts
         *  4.GetArtifact
         *  5.UpdateArtifact methods
         */
        private readonly IBaseGenericRepository<Artifact> _artifactRepository;
        private readonly IBaseGenericRepository<Room> _roomRepository;

        private readonly IMapper _mapper;
        public ArtifactService(IBaseGenericRepository<Artifact> repository, IBaseGenericRepository<Room> roomRepository, IMapper mapper)
        {
            _artifactRepository = repository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task CreateArtifact(CreateArtifactDTO input)
        {
            var artifact = _mapper.Map<Artifact>(input);
            artifact.Room = await _roomRepository.GetById(input.RoomId);
            await _artifactRepository.Create(artifact);
        }

        public async Task DeleteArtifact(DeleteArtifactDTO input)
        {
            await _artifactRepository.Delete(input.Id);
        }

        //ProjectID
        public async Task<List<ReadArtifactDTO>> GetAllArtifacts(EntityDTO input)
        {
            var artifacts = await _artifactRepository
                .GetAll()
                .Include(x => x.Room)
                .ThenInclude(x => x.Floor)
                .ThenInclude(x => x.Building)
                .Where(x => x.Project.Id == input.Id)
                .ToListAsync();

            List<ReadArtifactDTO> result = new List<ReadArtifactDTO>();
            foreach (var item in artifacts)
            {
                ReadArtifactDTO dto = new ReadArtifactDTO();

                dto = _mapper.Map<ReadArtifactDTO>(item);
                dto.RoomName = item.Room.Name;
                dto.FloorName = item.Room.Floor.Name;
                dto.BuildingName = item.Room.Floor.Building.Name;
                result.Add(dto);
            }
            return result;
        }

        public async Task<ReadArtifactDTO> GetArtifact(EntityDTO input)
        {
            var artifact = await _artifactRepository
                .GetAll()
                .Include(x => x.Room)
                .ThenInclude(x => x.Floor)
                .ThenInclude(x => x.Building)
                .FirstOrDefaultAsync(x => x.Id == input.Id);
            var result = _mapper.Map<ReadArtifactDTO>(artifact);
            result.RoomName = artifact.Room.Name;
            result.FloorName = artifact.Room.Floor.Name;
            result.BuildingName = artifact.Room.Floor.Building.Name;
            return result;
        }
        //roomID
        public async Task<List<ReadArtifactDTO>> GetArtifactsInRoom(EntityDTO input)
        {
            var artifacts = await _artifactRepository.GetAll()
                .Include(x => x.Room)
                .ThenInclude(x => x.Floor)
                .ThenInclude(x => x.Building)
                .Where(x => x.Room.Id == input.Id)
                .ToListAsync();
            List<ReadArtifactDTO> result = new List<ReadArtifactDTO>();
            foreach (var item in artifacts)
            {
                ReadArtifactDTO dto = new ReadArtifactDTO();

                dto = _mapper.Map<ReadArtifactDTO>(item);
                dto.RoomName = item.Room.Name;
                dto.FloorName = item.Room.Floor.Name;
                dto.BuildingName = item.Room.Floor.Building.Name;

                result.Add(dto);
            }
            return result;
        }

        public async Task UpdateArtifact(UpdateArtifactDTO input)
        {
            var artifact = await _artifactRepository.GetById(input.Id);

            artifact.Name = input.Name;
            if (input.RoomId != Guid.Empty)
                artifact.Room = await _roomRepository.GetById(input.RoomId);
            artifact.CreatedTime = DateTime.Now;
            if (!String.IsNullOrEmpty(input.MainImageURL))
                artifact.MainImageURL = input.MainImageURL;

            await _artifactRepository.Update(artifact.Id,artifact);
        }
    }
}
