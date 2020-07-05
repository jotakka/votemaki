using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Votemaki.Core.Entities.MainEntities;
using Votemaki.Core.Entities.SecondaryEntities;
using Votemaki.Core.IRepository;
using Votemaki.Infra.Storage;

namespace Votemaki.Infra.Repositories
{
    public class CalendarEventRepository : RepositoryBase<CalendarEvent>, ICalendarEventRepository
    {
        public CalendarEventRepository(
            TemakiContext temakiContext
            ) : base(temakiContext)
        {
        }

    }
}
