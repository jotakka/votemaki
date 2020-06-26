using System.Collections.Generic;
using Votemaki.Core.Entities.NavigationEntities;
    
namespace Votemaki.Core.Entities.MainEntities
{
    public class Voter : TemakiUser
    {
        public bool IsActive { get; set; } = true;
        public ICollection<VoterElection>  VoterElections{ get; set; }
    }
}
