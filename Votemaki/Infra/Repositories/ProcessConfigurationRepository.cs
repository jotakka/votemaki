using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votemaki.Core.Entities.ConfigurationEntities;
using Votemaki.Core.Entities.SecondaryEntities;
using Votemaki.Core.IRepositories;
using Votemaki.Infra.Storage;

namespace Votemaki.Infra.Repositories
{
    public class ProcessConfigurationRepository : IProcessConfigurationRepository
    {


        private readonly TemakiContext _temakiContext;
        public ProcessConfigurationRepository(
            TemakiContext temakiContext
            )
        {
            _temakiContext = temakiContext;
        }

        public async Task<Guid> AddAsync(ProcessConfiguration input)
        {
            if (await _temakiContext.ProcessConfigurations.AnyAsync())
            {
                throw new Exception("A process configuration has already been added");
            }

            addBasicCalendarEventObjects(input);

            await _temakiContext.ProcessConfigurations.AddAsync(input);
            await _temakiContext.SaveChangesAsync();

            return input.Id;
        }


        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task<ProcessConfiguration> GetAsync()
        {
            return await _temakiContext.ProcessConfigurations.FirstOrDefaultAsync();
        }


        public async Task<ProcessConfiguration> GetAsync(Guid id)
        {
            return await GetAsync();
        }

        public async Task UpdateAsync(ProcessConfiguration input)
        {
            var pc = await GetAsync();

            if(pc is null)
            {
                throw new Exception("There is no process configuration registered");
            }

            

            
        }


        private static void addBasicCalendarEventObjects(ProcessConfiguration input)
        {
            var calendarEvents = new List<CalendarEvent>() {
          new CalendarEvent()
            {
                Description = "",
                Type = CalendarEventTypeEnum.BeginPreElection,
                Value = DateTimeOffset.MinValue
            }, new CalendarEvent()
            {
                Description = "",
                Type = CalendarEventTypeEnum.BeginElection,
                Value = DateTimeOffset.MinValue
            },new CalendarEvent()
            {
                Description = "",
                Type = CalendarEventTypeEnum.EndElection,
                Value = DateTimeOffset.MinValue
            }

        };

            input.CalendarEvents = calendarEvents;
        }
    }
}
