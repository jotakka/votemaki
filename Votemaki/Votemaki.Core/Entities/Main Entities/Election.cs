using System;
using System.Collections.Generic;
using Votemaki.Core.Entities.ConfigurationEntities;
using Votemaki.Core.Entities.NavigationEntities;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Election
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid ProcessConfigurationId { get; set; }
        public Guid RegionId { get; set; }
        public ProcessConfiguration ProcessConfiguration { get; set; }
        public Region Region { get; set; }
        public IEnumerable<Votable> Votables { get; set; }
        public IEnumerable<VoterElection> VoterElections { get; set; }
        public IEnumerable<Vote> Votes { get; set; }
    }
}