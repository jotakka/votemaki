using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Votemaki.Core.Entities.NavigationEntity;

namespace Votemaki.Core.Entities
{
    public class Voter : ApplicationUser
    {
        public bool IsActive { get; set; } = true;
        public ICollection<VoterElection>  VoterElections{ get; set; }
    }
}
