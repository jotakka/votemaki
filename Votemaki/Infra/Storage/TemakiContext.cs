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
    public class TemakiContext : IdentityDbContext<TemakiUser, Role, Guid>
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
        public TemakiContext()
        {
        }

        public TemakiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Main Entities
            instituteEntityConfig(builder);

            electionEntityConfig(builder);

            votableEntityConfig(builder);

            regionEntityConfig(builder);

            voteEntityConfig(builder);

            identificationEntityConfig(builder);

            #endregion

            #region Configuration Entities

            processConfigurationEntityConfig(builder);

            passwordConfigurationEntityConfig(builder);



            #endregion

            #region Secondary Entities

            identificatorEntityConfig(builder);

            overallProcessRegisterEntityConfig(builder);

            #endregion

            #region Navigation Entities

            builder.Entity<VoterElection>(
                e =>
                {
                    e.HasKey(v => new { v.ElectionId,v.VoterId});
                    e.HasOne(v => v.Voter)
                    .WithMany(v => v.VoterElections)
                    .HasForeignKey(v => v.VoterId)
                    .OnDelete(DeleteBehavior.NoAction);
                    ;

                    e.HasOne(v => v.Election)
                    .WithMany(e => e.VoterElections)
                    .HasForeignKey(v => v.ElectionId)
                    .OnDelete(DeleteBehavior.NoAction);
                }
                
                );

            #endregion
        }

        private static void overallProcessRegisterEntityConfig(ModelBuilder builder)
        {
            builder.Entity<OverallProgressRegister>(
                e =>
                {
                    e.HasOne(e => e.ProcessConfiguration)
                    .WithOne(e => e.OverallProgressRegister)
                    .HasForeignKey<OverallProgressRegister>(e => e.ProcessConfigurationId);
                }
                );
        }

        private static void identificatorEntityConfig(ModelBuilder builder)
        {
            builder.Entity<IdentificatorType>(

                            e =>
                            {
                                e.HasOne(e => e.Institution)
                                .WithMany()
                                .HasForeignKey(e => e.InstitutionId);
                            }
                            );
        }

        private static void identificationEntityConfig(ModelBuilder builder)
        {
            builder.Entity<Identification>(
                e =>
                {
                    e.HasOne(i => i.IdentificatorType)
                        .WithMany()
                        .HasForeignKey(i => i.IdentificatorTypeId);
                }
                );
        }

        private static void voteEntityConfig(ModelBuilder builder)
        {
            builder.Entity<Vote>(e =>
            {
                e.HasOne(e => e.Election)
                    .WithMany(e => e.Votes)
                    .HasForeignKey(e => e.ElectionId);

            });
        }

        private static void regionEntityConfig(ModelBuilder builder)
        {
            builder.Entity<Region>(
                e =>
                {
                    e.HasOne(r => r.Institution)
                        .WithMany(i => i.Regions)
                        .HasForeignKey(r => r.InstitutionId);
                }
                );
        }

        private static void votableEntityConfig(ModelBuilder builder)
        {
            builder.Entity<Votable>(e =>
            {
                //e.HasOne(v => v.Election)
                //.WithMany(e => e.Votables)
                //.HasForeignKey(e => e.ElectionId);

            });
        }

        private static void electionEntityConfig(ModelBuilder builder)
        {
            builder.Entity<Election>(
                e =>
                {
                    e.HasMany(el => el.Votables)
                        .WithOne(v => v.Election)
                        .HasForeignKey(el => el.ElectionId)
                        .OnDelete(DeleteBehavior.NoAction);

                    e.HasMany(el => el.Votes)
                    .WithOne(el => el.Election)
                    .HasForeignKey(el => el.ElectionId);

                    e.HasMany(el => el.VoterElections)
                    .WithOne(ve => ve.Election)
                    .HasForeignKey(ve => ve.ElectionId);

                    e.HasOne(el => el.Region)
                    .WithMany()
                    .HasForeignKey(el => el.RegionId);

                    e.HasOne(el => el.ProcessConfiguration)
                    .WithMany(el => el.Elections)
                    .HasForeignKey(el => el.ProcessConfigurationId);
                }

                );
        }

        private static void passwordConfigurationEntityConfig(ModelBuilder builder)
        {
            builder.Entity<PasswordConfiguration>(e =>
            {
                e.HasOne(pc => pc.ProcessConfiguration)
                    .WithOne(pc => pc.PasswordConfiguration)
                    .HasForeignKey<PasswordConfiguration>(pc => pc.ProcessConfigurationId);
            });
        }

        private static void processConfigurationEntityConfig(ModelBuilder builder)
        {
            builder.Entity<ProcessConfiguration>(
                e =>
                {
                    e.HasMany(pc => pc.CalendarEvents)
                    .WithOne(cv => cv.ProcessConfiguration)
                    .HasForeignKey(cv => cv.ProcessConfigurationId);

                    e.HasMany(el => el.Elections)
                    .WithOne(el => el.ProcessConfiguration)
                    .HasForeignKey(el => el.ProcessConfigurationId);
                }
                );
        }

        private static void instituteEntityConfig(ModelBuilder builder)
        {
            builder.Entity<Institution>(e =>
            {
                e.HasMany(i => i.Regions)
                .WithOne(r => r.Institution)
                .HasForeignKey(i => i.InstitutionId);
                ;
            });
        }
    }
}
