using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Candidate : Votable
    {
        [ForeignKey("ApplicationUserId")]
        public Guid ApplicationUserId { get; set; }
        public TemakiUser? ApplicationUser { get; set; }
    }
}
