using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Votemaki.Infra.Storage;

namespace Infra.Test.InMemoryDb
{
    public class TemakiInMemoryContextFactory : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<TemakiContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<TemakiContext>()
                .UseSqlite(_connection).Options;
        }

        public TemakiContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using (var context = new TemakiContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new TemakiContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
