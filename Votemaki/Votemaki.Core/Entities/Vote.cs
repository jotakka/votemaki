using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Votemaki.Core.Entities
{
    public class Vote
    {
        [Key]
        public Guid Id{ get; set; }
        public byte[] EncryptedVote{ get; set; }
        public string DecryptedVotes { get; set; } = "";
        public bool IsDecrypted { get; set; } = false;
        public DateTimeOffset DecryptedAt { get; set; } = DateTimeOffset.MinValue;

        public Election Election { get; set; }
        public Guid ElectionId { get; set; }
    }
}
