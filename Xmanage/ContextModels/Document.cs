using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Xmanage.ContextModels
{
    public partial class Document
    {
        public Guid Id { get; set; }
        public Guid IdLabour { get; set; }
        public string Doc { get; set; }
        public Guid? IdUser { get; set; }

        public virtual Labour IdLabourNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
