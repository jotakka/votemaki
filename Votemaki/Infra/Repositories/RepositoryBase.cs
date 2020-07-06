using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Votemaki.Core.IRepository;
using Votemaki.Infra.Storage;

namespace Votemaki.Infra.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected readonly TemakiContext _temakiContext;

        public RepositoryBase(
            TemakiContext temakiContext
            )
        {
            _temakiContext = temakiContext;

        }

        public async Task<Guid> AddAsync(T input)
        {
            await _temakiContext.AddAsync<T>(input);
            await _temakiContext.SaveChangesAsync();
            var propertyId = input.GetType().GetProperty("Id");
            var value = propertyId.GetValue(input, null);
            return (Guid)value;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _temakiContext.FindAsync<T>(id);
            _temakiContext.Remove<T>(entity);
            await _temakiContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _temakiContext.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T input)
        {
            _temakiContext.Update(input);
            await _temakiContext.SaveChangesAsync();
        }
    }
}
