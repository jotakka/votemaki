using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votemaki.Core.Entities.SecondaryEntities;

namespace Votemaki.Core.Entities.ConfigurationEntities
{
    public class ProcessConfiguration
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(1), MinLength(150)]
        public string Institution { get; set; }

        public IEnumerable<CalendarEvent> CalendarEvents { get; set; }

        [ForeignKey("PasswordConfigurationId")]
        public Guid? PasswordConfigurationId { get; set; }

        public PasswordConfiguration PasswordConfiguration { get; set; }
    }
}