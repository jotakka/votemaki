using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Region
    {
        [Key]
        public Guid Id{ get; set; }
        public string RegionName { get; set; }
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}