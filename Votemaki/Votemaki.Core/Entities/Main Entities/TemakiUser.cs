using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Votemaki.Core.Entities.MainEntities
{
    public class TemakiUser : IdentityUser<string>
    {
        [Required]
        [MaxLength(1), MinLength(150)]
        public string Name { get; set; }
        [Required]
        public DateTimeOffset RegisteredAt { get; set; }

        public ICollection<Role> Roles{ get; set; }
        public ICollection<Identification> Identifications { get; set; }
    }
}
