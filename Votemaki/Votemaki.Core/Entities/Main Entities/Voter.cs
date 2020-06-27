using System.Collections.Generic;
using Votemaki.Core.Entities.NavigationEntities;
    
namespace Votemaki.Core.Entities.MainEntities
{
    public class Voter : TemakiUser
    {
        public bool IsActive { get; set; } = true;
        public IEnumerable<VoterElection>  VoterElections{ get; set; }
    }
}
