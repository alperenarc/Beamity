using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.ArtifactDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
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
        private readonly ArtifactRepository _repository;
        private readonly RoomRepository _roomRepository;

        private readonly IMapper _mapper;

        public ArtifactService(ArtifactRepository repository, RoomRepository roomRepository, IMapper mapper)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public void CreateArtifact(CreateArtifactDTO input)
        {
            var artifact = _mapper.Map<Artifact>(input);
            artifact.Room = _roomRepository.GetById(input.RoomId);
            _repository.Create(artifact);
        }

        public void DeleteArtifact(DeleteArtifactDTO input)
        {
            _repository.Delete(input.Id);
        }

        public List<ReadArtifactDTO> GetAllArtifacts()
        {
            var artifacts = _repository.GetAll();
            List<ReadArtifactDTO> result = new List<ReadArtifactDTO>();
            foreach (var item in artifacts)
            {
                ReadArtifactDTO dto = new ReadArtifactDTO();

                dto = _mapper.Map<ReadArtifactDTO>(item);
                dto.RoomName = item.Room.Name;

                result.Add(dto);
            }
            return result;
        }

        public ReadArtifactDTO GetArtifact(EntityDTO input)
        {
            var artifact = _repository.GetById(input.Id);
            var result = _mapper.Map<ReadArtifactDTO>(artifact);
            result.RoomName = artifact.Room.Name;
            return result;
        }

        public async Task<List<ReadArtifactDTO>> GetArtifactsInRoom(EntityDTO input)
        {
            var artifacts = await _repository.GetArtifactsWithRoomId(input.Id);
            List<ReadArtifactDTO> result = new List<ReadArtifactDTO>();
            foreach (var item in artifacts)
            {
                ReadArtifactDTO dto = new ReadArtifactDTO();

                dto = _mapper.Map<ReadArtifactDTO>(item);
                dto.RoomName = item.Room.Name;

                result.Add(dto);
            }
            return result;
        }

        public void UpdateArtifact(UpdateArtifactDTO input)
        {
            var artifact = _mapper.Map<Artifact>(input);
            _repository.Update(artifact);
        }
    }
}
