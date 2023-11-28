using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Xmanage.ContextModels
{
    public partial class CheckList
    {
        public Guid Id { get; set; }
        public Guid IdLabour { get; set; }
        public Guid IdUser { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateDeadline { get; set; }
        public DateTime? DateSolved { get; set; }
        public string Describe { get; set; }
        public int IdStatus { get; set; }
        public int IdPriority { get; set; }

        public virtual Labour IdLabourNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
