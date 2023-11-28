using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Xmanage.ContextModels
{
    public partial class Labour
    {
        public Labour()
        {
            Chat = new HashSet<Chat>();
            CheckList = new HashSet<CheckList>();
            Document = new HashSet<Document>();
            Workers = new HashSet<Workers>();
        }

        public Guid Id { get; set; }
        public string Company { get; set; }
        public Guid IdUser { get; set; }
        public string Describe { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateDeadline { get; set; }
        public DateTime? DateSolved { get; set; }
        public int IdPriority { get; set; }
        public int IdStatus { get; set; }

        public virtual Priority IdPriorityNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<CheckList> CheckList { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
