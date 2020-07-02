using System;
using System.Collections.Generic;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Party : Votable
    {
        public IEnumerable<Candidate> Candidates { get; set; }
        public Guid RegionId{ get; set; }
        public Region Region { get; set; }
    }
}