using System;
using System.ComponentModel.DataAnnotations;
using Votemaki.Core.Entities.MainEntities;

namespace Votemaki.Core.Entities.SecondaryEntities
{
    public class IdentificatorType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Regex { get; set; } = "";
        public Institution  Institution { get; set; }

        public  Guid  InstitutionId { get; set; }
    }
}