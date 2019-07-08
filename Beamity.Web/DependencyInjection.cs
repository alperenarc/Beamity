using AutoMapper;
using Beamity.Application;
using Beamity.Application.Service.IServices;
using Beamity.Application.Service.Services;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Beamity.Web.Blob;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beamity.Web
{
    public class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IArtifactService, ArtifactService>();
            services.AddTransient<IBeaconService, BeaconService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IFloorService, FloorService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRelationService, RelationService>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<RoomRepository, RoomRepository>();
            services.AddScoped<ArtifactRepository, ArtifactRepository>();
            services.AddScoped<ContentRepository, ContentRepository>();
            services.AddScoped<BeaconRepository, BeaconRepository>();
            services.AddScoped<ProjectRepository, ProjectRepository>();
            services.AddScoped<RelationRepository, RelationRepository>();
            services.AddScoped<LocationRepository, LocationRepository>();
            services.AddScoped<BuildingRepository, BuildingRepository>();
            services.AddScoped<FloorRepository, FloorRepository>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IBlobManager, BlobManager>();

            services.AddDbContext<BeamityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper();

        }
    }
}
