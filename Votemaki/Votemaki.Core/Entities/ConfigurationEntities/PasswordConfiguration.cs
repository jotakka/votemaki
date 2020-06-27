using System;
using System.ComponentModel.DataAnnotations;

namespace Votemaki.Core.Entities.ConfigurationEntities
{
    public class PasswordConfiguration
    {
        [Key]
        public Guid Id { get; set; }

        [Range(6, 10)]
        public uint MinLength { get; set; } = 6;

        public bool UpperCaseMandatory { get; set; } = false;
        public bool SpecialCharacterMandatory { get; set; } = false;
        public bool NumbersMandatory { get; set; } = false;
    }
}