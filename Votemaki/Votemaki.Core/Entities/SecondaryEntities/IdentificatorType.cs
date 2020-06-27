using System;
using System.ComponentModel.DataAnnotations;

namespace Votemaki.Core.Entities.SecondaryEntities
{
    public class IdentificatorType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Regex { get; set; }
    }
}