using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Votemaki.Core.Entities.MainEntities
{
    public class TemakiUser : IdentityUser<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        [Required]
        [MaxLength(1), MinLength(150)]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset RegisteredAt { get; set; }

        public Guid RegionId { get; set; }
        public Region Region { get; set; }

        public IEnumerable<TemakiRole> Roles { get; set; }
        public IEnumerable<Identification> Identifications { get; set; }
    }
}