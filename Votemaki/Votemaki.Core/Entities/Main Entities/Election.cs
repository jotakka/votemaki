using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Votemaki.Core.Entities.NavigationEntities;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Election 
    {
        public string Name { get; set; }
        public IEnumerable<Votable> Votables { get; set; }
        public IEnumerable<VoterElection> VoterElections { get; set; }
        public IEnumerable<Vote> Votes { get; set; }
    }
}
