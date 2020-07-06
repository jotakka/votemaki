using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Votemaki.Core.Entities.MainEntities;

namespace Votemaki.Core.IRepository
{
    public interface IInstitutionRepository: IRepositoryBase<Institution>
    {
        Task<Institution> GetFirst();
    }
}
