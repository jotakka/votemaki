using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Votemaki.Core.Entities.MainEntities;
using Votemaki.Core.IRepository;
using Votemaki.Infra.Repositories;
using Votemaki.Infra.Storage;

namespace Votemaki.Infra
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfraLibraryInjections(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ICalendarEventRepository, CalendarEventRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IElectionRepository, ElectionRepository>();
            services.AddScoped<IIdentificationRepository, IdentificationRepository>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IPartyRepository, PartyRepository>();
            services.AddScoped<IProcessConfigurationRepository, ProcessConfigurationRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            //ADD DB CONTEXT
            services.AddDbContext<TemakiContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //ADD IDENTITY
            services.AddIdentity<TemakiUser, TemakiRole>()
                     .AddEntityFrameworkStores<TemakiContext>()
                     .AddDefaultTokenProviders();


            return services;
        }
    }
}

