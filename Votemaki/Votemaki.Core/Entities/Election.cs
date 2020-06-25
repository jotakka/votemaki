using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Votemaki.Core.Entities.NavigationEntity;

namespace Votemaki.Core.Entities
{
    public class Election 
    {
        public string Name { get; set; }
        public ICollection<VoterElection> VoterElections { get; set; }
        public ICollection<Vote> Votes { get; set; }

    }
}
