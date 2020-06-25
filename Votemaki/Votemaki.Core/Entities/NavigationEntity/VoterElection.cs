using System;
using System.Collections.Generic;
using System.Text;

namespace Votemaki.Core.Entities.NavigationEntity
{
    public class VoterElection
    {

        public Guid ApplicationUserId { get; set; }
        public Guid ElectionId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public bool HasVoted { get; set; } = false;
        public Voter Voter { get; set; }
        public bool IsAllowedToVote { get; set; } = true;
        public DateTimeOffset CasttedAt { get; set; } = DateTimeOffset.MinValue;

    }
}
