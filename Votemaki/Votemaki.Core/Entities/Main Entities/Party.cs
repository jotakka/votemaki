using System.Collections.Generic;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Party : Votable
    {
        public IEnumerable<Candidate> Candidates { get; set; }
    }
}