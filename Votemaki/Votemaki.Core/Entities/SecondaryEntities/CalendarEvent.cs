using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Votemaki.Core.Entities.ConfigurationEntities;

namespace Votemaki.Core.Entities.SecondaryEntities
{
    public class CalendarEvent

    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Um valor dever ser escolhido para a data")]
        [DataType(DataType.Date)]
        public DateTimeOffset Value { get; set; }
        [Required(ErrorMessage ="Uma descrição para o evento deve ser inserida")]
        [MaxLength(1, ErrorMessage = "O campo de descriçao de evento deve ter pelo menos 1 caracter"), MinLength(150, ErrorMessage = "O campo de descriçao de evento deve ter no máximo 150 caracteres")]
        [Display(Name = "Nome da insituição")]
        public string Description { get; set; }

        public Guid ProcessConfigurationId { get; set; }
        public ProcessConfiguration ProcessConfiguration { get; set; }
        public CalendarEventTypeEnum Type { get; set; }
    }

    public enum CalendarEventTypeEnum
    {
        BeginElection,
        EndElection,
        BeginPreElection,

        Others
    }
}