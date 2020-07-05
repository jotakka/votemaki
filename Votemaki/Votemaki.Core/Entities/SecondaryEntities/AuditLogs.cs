using System;
using System.ComponentModel.DataAnnotations;

namespace Votemaki.Core.Entities.SecondaryEntities
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string OriginIp { get; set; }
        public AuditLogType Type { get; set; }
        public EntityTypeEnum EntityType { get; set; }
        public Guid EntityId { get; set; }
    }

    #region ENUMS

    public enum EntityTypeEnum
    {
        Voter,
        Candidate,
        Party,
    }

    public enum AuditLogType
    {
        Voter,
        Candidate,
        Party,
    }

    #endregion ENUMS
}