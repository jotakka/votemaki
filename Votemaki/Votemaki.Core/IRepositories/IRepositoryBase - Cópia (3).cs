using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Votemaki.Core.IRepositories
{
    public interface IRepositoryBase<T>
    {
        Task<Guid> AddAsync(T input);
        Task Delete(Guid id);
        Task Update(T input);
        Task<T> Get(Guid id);
    }
}
