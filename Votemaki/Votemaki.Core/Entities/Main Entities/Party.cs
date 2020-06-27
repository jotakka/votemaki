using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votemaki.Core.Entities.MainEntities
{
    public class Party : Votable
    {
        public IEnumerable<Candidate> Candidates { get; set; }
    }
}
