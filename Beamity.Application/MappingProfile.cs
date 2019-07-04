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
            

            CreateMap<Artifact, ReadArtifactDTO>();

            CreateMap<UpdateArtifactDTO, Artifact>();
            CreateMap<CreateRoomDTO, Room>();

            CreateMap<Room, ReadRoomDTO>();

            CreateMap<UpdateRoomDTO, Room>();

            CreateMap<CreateRelationDTO, Relation>();
            CreateMap<Relation, ReadRelationDTO>();
            CreateMap<UpdateRelationDTO, Relation>();

            CreateMap<CreateProjectDTO,Project>();
            CreateMap<Project, ReadProjectDTO>();
            CreateMap<UpdateProjectDTO, Project>();

            CreateMap<CreateLocationDTO, Location>();
            CreateMap<Location, ReadLocationDTO>();
            CreateMap<UpdateLocationDTO,Location>();

            CreateMap<CreateFloorDTO, Floor>();
            CreateMap<Floor, ReadFloorDTO>();
            CreateMap<UpdateFloorDTO,Floor>();

            CreateMap<CreateContentDTO,Content>();
            CreateMap<Content, ReadContentDTO>();
            CreateMap<UpdateContentDTO, Content>();

            CreateMap<CreateBuildingDTO,Building>();
            CreateMap<Building, ReadBuildingDTO>();
            CreateMap<UpdateBuildingDTO, Building>();

            CreateMap<CreateBeaconDTO,Beacon>();
            CreateMap<Beacon, ReadBeaconDTO>();
            CreateMap<UpdateBeaconDTO, Beacon>();
        }
    }
}
