using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using Votemaki.Infra.Storage;

namespace Votemaki.Infra.Storage
{
    public class TemakiContextFactory : IDesignTimeDbContextFactory<TemakiContext>
    {

        public TemakiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TemakiContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NMBSDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new TemakiContext(optionsBuilder.Options);
        }
    }
}
