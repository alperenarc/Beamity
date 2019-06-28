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
        private readonly BaseRepository<Room> _roomRepository;

        private readonly IMapper _mapper;

        public ArtifactService(ArtifactRepository repository, BaseRepository<Room> roomRepository, IMapper mapper)
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
            var artifact = _mapper.Map<Artifact>(input);
            _repository.Delete(artifact);
        }

        public List<ReadArtifactDTO> GetAllArtifacts()
        {
            var artifacts = _repository.GetAll();
            var result = _mapper.Map<List<ReadArtifactDTO>>(artifacts);
            return result;
        }

        public ReadArtifactDTO GetArtifact(EntityDTO input)
        {
            var artifacts = _repository.GetById(input.Id);
            var result = _mapper.Map<ReadArtifactDTO>(artifacts);
            return result;
        }

        public void UpdateArtifact(UpdateArtifactDTO input)
        {
            var artifact = _mapper.Map<Artifact>(input);
            _repository.Update(artifact);
        }
    }
}
