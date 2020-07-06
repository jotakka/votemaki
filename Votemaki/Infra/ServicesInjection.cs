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

            services.AddSingleton<ICalendarEventRepository, CalendarEventRepository>();
            services.AddSingleton<ICandidateRepository, CandidateRepository>();
            services.AddSingleton<IElectionRepository, ElectionRepository>();
            services.AddSingleton<IIdentificationRepository, IdentificationRepository>();
            services.AddSingleton<IInstitutionRepository, InstitutionRepository>();
            services.AddSingleton<IPartyRepository, PartyRepository>();
            services.AddSingleton<IProcessConfigurationRepository, ProcessConfigurationRepository>();
            services.AddSingleton<IRegionRepository, RegionRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();

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

