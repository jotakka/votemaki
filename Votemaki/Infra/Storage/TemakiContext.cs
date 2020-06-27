using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Votemaki.Core.Entities.ConfigurationEntities;
using Votemaki.Core.Entities.MainEntities;
using Votemaki.Core.Entities.NavigationEntities;
using Votemaki.Core.Entities.SecondaryEntities;

namespace Votemaki.Infra.Storage
{
    public class TemakiContext : IdentityDbContext<TemakiUser, Role, string>
    {
        #region ENTITY DB SETS
        public DbSet<Election> Elections { get; internal set; }
        public DbSet<Candidate> Candidates { get; internal set; }
        public DbSet<Identification> Identifications { get; internal set; }
        public DbSet<Party> Parties { get; internal set; }
        public DbSet<Votable> Votables { get; internal set; }
        public DbSet<Vote> Votes { get; internal set; }
        public DbSet<Voter> Voters { get; internal set; }
        public DbSet<ProcessConfiguration> ProcessConfigurations { get; internal set; }
        public DbSet<PasswordConfiguration> PasswordConfigurations { get; internal set; }
        public DbSet<VoterElection> VoterElections { get; internal set; }
        public DbSet<AuditLog> AuditLogs { get; internal set; }
        public DbSet<CalendarEvent> CalendarEvents { get; internal set; }
        public DbSet<IdentificatorType> IdentificatorTypes { get; internal set; }
        public DbSet<OverallProgressRegister> OverallProgressRegisters { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
