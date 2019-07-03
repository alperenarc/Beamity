using AutoMapper;
using Beamity.Application.DTOs.ArtifactDTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.BuildingDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.FloorDTOs;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.DTOs.ProjectDTOs;
using Beamity.Application.DTOs.RelationDTO;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.DTOs.UserDTOs;
using Beamity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<CreateArtifactDTO, Artifact>();
            CreateMap<ReadArtifactDTO, Artifact>();
            CreateMap<UpdateArtifactDTO, Artifact>();
            CreateMap<CreateRoomDTO, Room>();
            CreateMap<ReadRoomDTO, Room>();
            CreateMap<UpdateRoomDTO, Room>();
            CreateMap<CreateRelationDTO, Relation>();
            CreateMap<ReadRelationDTO, Relation>();
            CreateMap<UpdateRelationDTO, Relation>();
            CreateMap<CreateProjectDTO,Project>();
            CreateMap<ReadProjectDTO, Project>();
            CreateMap<UpdateProjectDTO, Project>();
            CreateMap<CreateLocationDTO, Location>();
            CreateMap<ReadLocationDTO, Location>();
            CreateMap<UpdateLocationDTO,Location>();
            CreateMap<CreateFloorDTO,Floor>();
            CreateMap<ReadFloorDTO,Floor>();
            CreateMap<UpdateFloorDTO,Floor>();
            CreateMap<CreateContentDTO,Content>();
            CreateMap<ReadContentDTO, Content>();
            CreateMap<UpdateContentDTO, Content>();
            CreateMap<CreateBuildingDTO,Building>();
            CreateMap<ReadBuildingDTO, Building>();
            CreateMap<UpdateBuildingDTO, Building>();
            CreateMap<CreateBeaconDTO,Beacon>();
            CreateMap<ReadBeaconDTO, Beacon>();
            CreateMap<UpdateBeaconDTO, Beacon>();
        }
    }
}
