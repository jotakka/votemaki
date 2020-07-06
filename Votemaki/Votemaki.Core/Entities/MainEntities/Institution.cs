using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Votemaki.Core.Entities.ConfigurationEntities;
using Votemaki.Core.Entities.MainEntities;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Institution
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome da instituição deve ser preenchido.")]
        [MinLength(1, ErrorMessage = "O nome da instituição deve ter pelo menos 1 caracter"), MaxLength(150, ErrorMessage = "O nome da instituição deve ter no máximo 150 caracteres")]
        [Display(Name = "Nome da insituição")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Uma descrição para a instituição é obrigatoria.")]
        [MinLength(10, ErrorMessage = "A descrição deve ter pelo menos 10 caracter"), MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        [Display(Name = "Descrição da instituição")]
        public string Description { get; set; }

        [MaxLength(150, ErrorMessage = "O endereço da instituição deve ter no máximo 200 caracteres")]
        [Display(Name = "Endereço da instituição")]
        public string Address { get; set; }

        public IEnumerable<ProcessConfiguration> ProcessConfigurations { get; set; }
        public IEnumerable<Region> Regions{ get; set; }

    }

}
