using Beamity.Application.Service.IServices;
using Beamity.Application.Service.Services;
using Beamity.Application.Tokens;
using Beamity.Core.Models.Tokens;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Beamity.API
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


            services.AddSingleton<ITokenHandler,Beamity.Application.Tokens.TokenHandler>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfigurations.Key,
                        ClockSkew = TimeSpan.FromMinutes(60)
                    };
                });
        }
    }
}
