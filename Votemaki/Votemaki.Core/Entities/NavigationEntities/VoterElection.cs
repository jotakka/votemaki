using System;
using Votemaki.Core.Entities.MainEntities;

namespace Votemaki.Core.Entities.NavigationEntities
{
    public class VoterElection
    {
        public Guid ElectionId { get; set; }
        public Election Election { get; set; }
        public bool HasVoted { get; set; } = false;
        public Guid VoterId { get; set; }
        public Voter Voter { get; set; }
        public bool IsAllowedToVote { get; set; } = true;
        public DateTimeOffset CasttedAt { get; set; } = DateTimeOffset.MinValue;
    }
}