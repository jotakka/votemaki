using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votemaki.Core.Entities.SecondaryEntities;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Identification
    {
        public Guid Id { get; set; }

        [Required]
        public string Value { get; set; }

        [ForeignKey("IdentificatorTypeId")]
        public Guid IdentificatorTypeId { get; set; }

        public IdentificatorType IdentificatorType { get; set; }
    }
}