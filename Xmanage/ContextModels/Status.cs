using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Xmanage.ContextModels
{
    public partial class Status
    {
        public Status()
        {
            Labour = new HashSet<Labour>();
        }

        public int Id { get; set; }
        public string Describe { get; set; }

        public virtual ICollection<Labour> Labour { get; set; }
    }
}
