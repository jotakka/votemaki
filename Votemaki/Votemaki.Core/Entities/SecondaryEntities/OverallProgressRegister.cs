using System;
using System.ComponentModel.DataAnnotations;

namespace Votemaki.Core.Entities.SecondaryEntities
{
    public class OverallProgressRegister
    {
        [Key]
        public Guid Id { get; set; }
        public bool HasProcessConfiguration { get; set; } = false;
        public bool HasMainCalendarEvents { get; set; } = false;
        public bool HasCandidates { get; set; } = false;
        public bool HasPasswordConfiguration { get; set; } = false;
        public bool HasVoters { get; set; } = false;
        public bool HasVotables { get; set; } = false;
    }
}