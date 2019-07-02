using Beamity.Application.Service.IServices;
using Beamity.Application.Service.Services;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.API
{
    public class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IArtifactService, ArtifactService>();
            services.AddTransient<IBeaconService, BeaconService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IFloorService, FloorService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<RoomRepository, RoomRepository>();
            services.AddScoped<ArtifactRepository, ArtifactRepository>();
            services.AddScoped<ContentRepository, ContentRepository>();
            services.AddScoped<BeaconRepository, BeaconRepository>();
            services.AddScoped<ProjectRepository, ProjectRepository>();
            services.AddScoped<LocationRepository, LocationRepository>();
            services.AddScoped<BuildingRepository, BuildingRepository>();
            services.AddScoped<FloorRepository, FloorRepository>();
            services.AddScoped<UserRepository, UserRepository>();
        }
    }
}
