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
        public DbSet<OverallProgressRegister> OverallProgressRegisters { get; internal set; }
        public DbSet<Institution> Institutons { get; internal set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            instituteEntityConfig(builder);

            processConfigurationEntityConfig(builder);

            builder.Entity<PasswordConfiguration>(e =>
            {
                e.HasOne(pc => pc.ProcessConfiguration)
                    .WithOne(pc => pc.PasswordConfiguration)
                    .HasForeignKey<ProcessConfiguration>(pc => pc.PasswordConfigurationId);

            });


        }

        private static void processConfigurationEntityConfig(ModelBuilder builder)
        {
            builder.Entity<ProcessConfiguration>(
                e =>
                {
                    e.HasOne(pc => pc.Institution)
                        .WithMany(pc => pc.ProcessConfigurations)
                        .HasForeignKey(pc => pc.InstitutionId);

                    e.HasMany(pc => pc.CalendarEvents)
                    .WithOne(cv => cv.ProcessConfiguration)
                    .HasForeignKey(cv => cv.ProcessConfigurationId);

                }
                );
        }

        private static void instituteEntityConfig(ModelBuilder builder)
        {
            builder.Entity<Institution>(e =>
            {
                e.HasMany(i => i.ProcessConfigurations)
                .WithOne(pc => pc.Institution)
                .HasForeignKey(pc => pc.InstitutionId);
                e.HasMany(i => i.Regions);
            });
        }
    }
}
