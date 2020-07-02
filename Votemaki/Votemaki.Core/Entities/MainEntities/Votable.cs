using System;
using System.ComponentModel.DataAnnotations;

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