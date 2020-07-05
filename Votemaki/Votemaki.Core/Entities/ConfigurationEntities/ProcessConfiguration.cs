using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votemaki.Core.Entities.MainEntities;
using Votemaki.Core.Entities.SecondaryEntities;

namespace Votemaki.Core.Entities.ConfigurationEntities
{
    public class ProcessConfiguration
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="O nome do processo deve ser preenchido.")]
        [MaxLength(1,ErrorMessage ="O nome do processo deve ter pelo menos 1 caracter"), MinLength(150, ErrorMessage = "O nome do processo deve ter no máximo 150 caracteres")]
        [Display(Name = "Nome do processo")]
        public string Name { get; set; }
        public PasswordConfiguration PasswordConfiguration { get; set; }
        public Institution Institution{ get; set; }
        public IEnumerable<CalendarEvent> CalendarEvents { get; set; }
        public IEnumerable<Election> Elections { get; set; }
        public OverallProgressRegister OverallProgressRegister { get; set; }

    }
}