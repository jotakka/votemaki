using Infra.Test.InMemoryDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votemaki.Core.Entities.ConfigurationEntities;
using Votemaki.Core.Entities.MainEntities;
using Votemaki.Infra.Repositories;
using Xunit;

namespace Infra.Test.Repositories
{
    public class BaseRepositoryTest
    {


        [Fact]
        public async Task TestAddAsync()
        {
            var institute = createInstitutionInstance();
            using (var factory = new TemakiInMemoryContextFactory())
            {
                using (var context = factory.CreateContext())
                {
                    var instituteRepository = new InstitutionRepository(context);
                    await instituteRepository.AddAsync(institute);
                    await context.SaveChangesAsync();
                }

                using (var context = factory.CreateContext())
                {
                    var success = await context.Institutions.AnyAsync(
                        i1 => (i1.Address == institute.Address) && (i1.Name == institute.Name)
                        );

                    Assert.True(success);
                }
            }
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var institute = createInstitutionInstance();
            using (var factory = new TemakiInMemoryContextFactory())
            {
                var id = await SaveInstitute(factory, institute);


                using (var context = factory.CreateContext())
                {
                    var repository = new InstitutionRepository(context);
                    var institionGotten = await repository.GetAsync(id);


                    Assert.True(
                        compareInstitutes(institute, institionGotten)
                        );
                }
            }
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var institute = createInstitutionInstance();
            using (var factory = new TemakiInMemoryContextFactory())
            {
                var id = await SaveInstitute(factory, institute);

                var institution2 = new Institution()
                {
                    Id = id,
                    Name = "minha casa",
                    Address = "nossa casa"
                };
                using (var context = factory.CreateContext())
                {
                    var repository = new InstitutionRepository(context);

                   

                    await repository.UpdateAsync(institution2);
                }

                var institutionGotten = await GetInstitution(factory, id);

                Assert.True(
                    compareInstitutes(institution2, institutionGotten)
                    );
            }
        }

        [Fact]
        public async Task TestDeleteAsync()
        {
            var institute = createInstitutionInstance();
            using (var factory = new TemakiInMemoryContextFactory())
            {
                var id = await SaveInstitute(factory, institute);


                using (var context = factory.CreateContext())
                {
                    var repository = new InstitutionRepository(context);



                    await repository.DeleteAsync(id);
                }

                var institutionGotten = await GetInstitution(factory, id);

                Assert.True(
                    institutionGotten is null
                    );
            }
        }





        private bool compareInstitutes(Institution i1, Institution i2)
        {
            return (i1.Address == i2.Address) && (i1.Name == i2.Name);
        }

        private static async Task<Guid> SaveInstitute(TemakiInMemoryContextFactory ctxf, Institution i)
        {
            using (var ctx = ctxf.CreateContext())
            {
                await ctx.AddAsync<Institution>(i);
                await ctx.SaveChangesAsync();
                return i.Id;
            }
        }

        private static async Task<Institution> GetInstitution(TemakiInMemoryContextFactory fac, Guid id)
        {
            using (var context = fac.CreateContext())
            {
                return await context.FindAsync<Institution>(id);
            }
        }

        private static Institution createInstitutionInstance()
        {

            return new Institution()
            {
                Address = "Quadra um",
                Name = "Institution",
                ProcessConfigurations = new List<ProcessConfiguration>(),
                Regions = new List<Region>()
            };
        }
    }

}
