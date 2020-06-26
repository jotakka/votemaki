using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;  

namespace Votemaki.Core.Entities.SecondaryEntities
{
    public class AuditLogs 
    {
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


    #endregion


}
