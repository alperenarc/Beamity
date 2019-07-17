using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
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
    public class RelationService : IRelationService
    {
        private readonly IBaseGenericRepository<Relation> _relationRepository;
        private readonly IBaseGenericRepository<Beacon> _beaconRepository;
        private readonly IBaseGenericRepository<Artifact> _artifactRepository;
        private readonly IBaseGenericRepository<Content> _contentRepository;

        private readonly IMapper _mapper;

        public RelationService(IBaseGenericRepository<Relation> relationRepository,
                                IBaseGenericRepository<Beacon> beaconRepository,
                                IBaseGenericRepository<Artifact> artifactRepository,
                                IBaseGenericRepository<Content> contentRepository, IMapper mapper)
        {
            _relationRepository = relationRepository;
            _beaconRepository = beaconRepository;
            _artifactRepository = artifactRepository;
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public async Task CreateRelation(CreateRelationDTO input)
        {
            Relation relation = new Relation()
            {
                ArtifactId = input.ArtifactId,
                ContentId = input.ContentId,
                BeaconId = input.BeaconId,
                Proximity = (Proximity)Enum.Parse(typeof(Proximity), input.Proximity, true),

            };
            relation.LocationId = input.LocationId;
            await _relationRepository.Create(relation);
        }

        public async Task DeleteRelationDTO(DeleteRelationDTO input)
        {
            await _relationRepository.Delete(input.Id);
        }

        public async Task<List<ReadRelationDTO>> GetAllRelations(EntityDTO input)
        {
            List<Relation> relations = await _relationRepository.GetAll()
                .Include(z => z.Location)
                .Where(z => z.IsActive == true && z.Location.Id == input.Id)
                .ToListAsync();
            List<ReadRelationDTO> result = new List<ReadRelationDTO>();
            foreach (Relation item in relations)
            {
                ReadRelationDTO dto = new ReadRelationDTO
                {
                    Id = item.Id,
                    CreatedTime = item.CreatedTime,
                    ArtifacName = item.Artifact.Name,
                    BeaconName = item.Beacon.Name,
                    ContentName = item.Content.Name
                };
                switch (item.Proximity)
                {
                    case Proximity.Unknown:
                        dto.Proximity = "Unknown";
                        break;
                    case Proximity.Far:
                        dto.Proximity = "Far";
                        break;
                    case Proximity.Near:
                        dto.Proximity = "Near";
                        break;
                    case Proximity.Immediate:
                        dto.Proximity = "Immediate";
                        break;
                    case Proximity.All:
                        dto.Proximity = "All";
                        break;
                    default:
                        dto.Proximity = "Unknown";
                        break;
                }

                result.Add(dto);
            }
            return result;
        }

        public async Task<ReadRelationDTO> GetRelation(EntityDTO input)
        {
            Relation relation = await _relationRepository.GetById(input.Id);

            ReadRelationDTO result = new ReadRelationDTO()
            {
                Id = relation.Id,
                CreatedTime = relation.CreatedTime,
                ArtifacName = relation.Artifact.Name,
                BeaconName = relation.Beacon.Name,
                ContentName = relation.Content.Name
            };
            switch (relation.Proximity)
            {
                case Proximity.Unknown:
                    result.Proximity = "Unknown";
                    break;
                case Proximity.Far:
                    result.Proximity = "Far";
                    break;
                case Proximity.Near:
                    result.Proximity = "Near";
                    break;
                case Proximity.Immediate:
                    result.Proximity = "Immediate";
                    break;
                case Proximity.All:
                    result.Proximity = "All";
                    break;
                default:
                    result.Proximity = "Unknown";
                    break;
            }
            return result;
        }

        public async Task<ReadContentDTO> GetContentWithBeacon(GetContentWithBeaconDTO input)
        {
            //Get Beacon for Major Minor and UUID.
            var beacon = await _beaconRepository.GetAll()
                .FirstOrDefaultAsync(x => x.UUID == input.UUID && x.Major == input.Major && x.Minor == input.Minor);

            //Get Relation for beacon ID
            var relation = await _relationRepository.GetAll()
                .Include(x => x.Beacon)
                .Where(x => x.Beacon.Id == beacon.Id).FirstOrDefaultAsync();

            ReadContentDTO da = new ReadContentDTO();
            if (relation != null)
                return _mapper.Map<ReadContentDTO>(relation.Content);
            else
            {
                return da;
            }
        }

        public async Task UpdateRelation(UpdateRelationDTO input)
        {

            Relation result = await _relationRepository.GetById(input.Id);

            if (input.ArtifactId != Guid.Empty)
            {
                result.Artifact = await _artifactRepository.GetById(input.ArtifactId);
                result.Location = result.Artifact.Location;
            }
            if (input.BeaconId != Guid.Empty)
                result.Beacon = await _beaconRepository.GetById(input.BeaconId);
            if (input.ContentId != Guid.Empty)
                result.Content = await _contentRepository.GetById(input.ContentId);
            if (!String.IsNullOrEmpty(input.Proximity))
                result.Proximity = (Proximity)Enum.Parse(typeof(Proximity), input.Proximity, true);

            var artifact = await _artifactRepository.GetAll()
                .Include(x => x.Location)
                .Where(x => x.Id == input.Id)
                .FirstOrDefaultAsync();
            result.Location = artifact.Location;

            await _relationRepository.Update(input.Id, result);
        }
    }
}
