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
        public ICollection<Votable> Votables { get; set; }
        public ICollection<VoterElection> VoterElections { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
