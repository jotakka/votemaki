using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Votemaki.Core.Entities.MainEntities;
using Votemaki.Core.IRepository;
using Votemaki.Infra.Storage;

namespace Votemaki.Infra.Repositories
{
    public class InstitutionRepository : RepositoryBase<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(
            TemakiContext temakiContext
            ) : base(temakiContext)
        {
        }


        public async Task<Institution> GetFirst()
        {
            return await _temakiContext.Institutions.FirstOrDefaultAsync();
        }

    }
}
