using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votemaki.Core.Entities
{
    public class Party 
    {
        public string Picture { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }

        public string Name { get; set; }
        public int? Number { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}
