using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
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
