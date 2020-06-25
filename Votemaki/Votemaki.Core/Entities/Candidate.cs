using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Votemaki.Core.Entities
{
    public class Candidate : ApplicationUser
    {

        public string Picture { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }

    }
}
