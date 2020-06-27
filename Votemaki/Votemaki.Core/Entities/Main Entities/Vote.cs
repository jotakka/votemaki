using System;
using System.ComponentModel.DataAnnotations;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Vote
    {
        [Key]
        public Guid Id { get; set; }

        public byte[] EncryptedVote { get; set; }
        public string DecryptedVotes { get; set; } = "";
        public bool IsDecrypted { get; set; } = false;
        public DateTimeOffset DecryptedAt { get; set; } = DateTimeOffset.MinValue;

        public Election Election { get; set; }
        public Guid ElectionId { get; set; }
    }
}