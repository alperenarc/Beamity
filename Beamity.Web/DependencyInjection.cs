using AutoMapper;
using Beamity.Application;
using Beamity.Application.Service.IServices;
using Beamity.Application.Service.Services;
using Beamity.Application.Tokens;
using Beamity.Core.Models;
using Beamity.Core.Models.Tokens;
using Beamity.EntityFrameworkCore.EntityFrameworkCore;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Beamity.Web.Blob;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

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
            services.AddScoped<IBaseGenericRepostiory, IBaseGenericRepostiory>();
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

            services.AddSingleton<ITokenHandler, Beamity.Application.Tokens.TokenHandler>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            options => 
            {
                    options.LoginPath = new PathString("/User/Login/");
                    options.AccessDeniedPath = new PathString("/User/Register/");
            });

            services.AddScoped(typeof(IBaseGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IBaseGenericRepository<Project>), typeof(GenericRepository<Project>));
            services.AddScoped(typeof(IBaseGenericRepository<Artifact>), typeof(GenericRepository<Artifact>));
            services.AddScoped(typeof(IBaseGenericRepository<Beacon>), typeof(GenericRepository<Beacon>));
            services.AddScoped(typeof(IBaseGenericRepository<Content>), typeof(GenericRepository<Content>));
            services.AddScoped(typeof(IBaseGenericRepository<Room>), typeof(GenericRepository<Room>));
            services.AddScoped(typeof(IBaseGenericRepository<Floor>), typeof(GenericRepository<Floor>));
            services.AddScoped(typeof(IBaseGenericRepository<Building>), typeof(GenericRepository<Building>));
            services.AddScoped(typeof(IBaseGenericRepository<Location>), typeof(GenericRepository<Location>));
            services.AddScoped(typeof(IBaseGenericRepository<User>), typeof(GenericRepository<User>));
            services.AddScoped(typeof(IBaseGenericRepository<Relation>), typeof(GenericRepository<Relation>));

        }
    }
}
