using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class RelationService : IRelationService
    {
        private readonly RelationRepository _relationRepository;
        private readonly BeaconRepository _beaconRepository;
        private readonly ArtifactRepository _artifactRepository;
        private readonly ContentRepository _contentRepository;

        private readonly IMapper _mapper;

        public RelationService(RelationRepository relationRepository,
                                BeaconRepository beaconRepository,
                                ArtifactRepository artifactRepository,
                                ContentRepository contentRepository, IMapper mapper)
        {
            _relationRepository = relationRepository;
            _beaconRepository = beaconRepository;
            _artifactRepository = artifactRepository;
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public void CreateRelation(CreateRelationDTO input)
        {
            Relation relation = new Relation()
            {
                Artifact = _artifactRepository.GetById(input.ArtifactId),
                Content = _contentRepository.GetById(input.ContentId),
                Beacon = _beaconRepository.GetById(input.BeaconId),
                Proximity = (Proximity)Enum.Parse(typeof(Proximity), input.Proximity, true)
            };
            _relationRepository.Create(relation);
        }

        public void DeleteRelationDTO(DeleteRelationDTO input)
        {
            _relationRepository.Delete(input.Id);
        }

        public List<ReadRelationDTO> GetAllRelations()
        {
            List<Relation> relations = _relationRepository.GetAll();
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

        public ReadRelationDTO GetRelation(EntityDTO input)
        {
            Relation relation = _relationRepository.GetById(input.Id);

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

        public ReadContentDTO GetContentWithBeacon(GetContentWithBeaconDTO input)
        {

            var beacon = _beaconRepository.GetBeaconWithName(input.UUID,input.Minor,input.Major);

            var relation = _relationRepository.GetRelationWithBeaconId(beacon.Id, input.Proximity);
            return _mapper.Map<ReadContentDTO>(relation.Content);
        }

        public void UpdateRelation(UpdateRelationDTO input)
        {

            Relation result = _relationRepository.GetById(input.Id);

            if( input.ArtifactId != Guid.Empty )
                result.Artifact = _artifactRepository.GetById(input.ArtifactId);
            if (input.BeaconId != Guid.Empty)
                result.Beacon = _beaconRepository.GetById(input.BeaconId);
            if (input.ContentId != Guid.Empty)
                result.Content = _contentRepository.GetById(input.ContentId);
            if ( !String.IsNullOrEmpty(input.Proximity) )
                result.Proximity = (Proximity)Enum.Parse(typeof(Proximity), input.Proximity, true);
            


            _relationRepository.Update(result);
        }
    }
}
