using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Votemaki.Core.IRepositories
{
    public interface IRepositoryBase<T>
    {
        Task<Guid> AddAsync(T input);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T input);
        Task<T> GetAsync(Guid id);
    }
}
