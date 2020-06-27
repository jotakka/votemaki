using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Candidate : Votable
    {
        [ForeignKey("ApplicationUserId")]
        public Guid ApplicationUserId { get; set; }

        public TemakiUser? ApplicationUser { get; set; }
    }
}