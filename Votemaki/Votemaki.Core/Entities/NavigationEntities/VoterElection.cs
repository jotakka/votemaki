using System;
using System.Collections.Generic;
using System.Text;
using Votemaki.Core.Entities.MainEntities;

namespace Votemaki.Core.Entities.NavigationEntities
{
    public class VoterElection
    {

        public Guid ApplicationUserId { get; set; }
        public Guid ElectionId { get; set; }
        public TemakiUser ApplicationUser { get; set; }
        public bool HasVoted { get; set; } = false;
        public Voter Voter { get; set; }
        public bool IsAllowedToVote { get; set; } = true;
        public DateTimeOffset CasttedAt { get; set; } = DateTimeOffset.MinValue;

    }
}
