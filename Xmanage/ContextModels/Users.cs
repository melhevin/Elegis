using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Xmanage.ContextModels
{
    public partial class Users
    {
        public Users()
        {
            Chat = new HashSet<Chat>();
            CheckList = new HashSet<CheckList>();
            Document = new HashSet<Document>();
            Labour = new HashSet<Labour>();
            Workers = new HashSet<Workers>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Checked { get; set; }
        public string NameSurname { get; set; }

        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<CheckList> CheckList { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Labour> Labour { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
