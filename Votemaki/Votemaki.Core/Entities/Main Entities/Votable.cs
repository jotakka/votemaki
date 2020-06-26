using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Votemaki.Core.Entities.NavigationEntities;

namespace Votemaki.Core.Entities.MainEntities
{
    public abstract class Votable
    {
        [Key]
        public Guid Id { get; set; }
        public string PublicName { get; set; } = "";
        public string Description { get; set; } = "";
        public string PictureUrl { get; set; } = "";
        public uint? Number { get; set; }
        public bool Approved { get; set; } = false;
        public uint? PresentationOrder { get; set; }
    }
}
