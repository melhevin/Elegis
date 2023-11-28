using System;
using static Xmanage.Models.HomeMethods.LabourMethods;
using Xmanage.ContextModels;
using Kendo.Mvc.Extensions;
using System.Linq;

namespace Xmanage.Models.HomeMethods
{
    public class CheckListMethods
    {
        public class CheckListGrid
        {
            public Guid? Id { get; set; }
            public Guid? IdLabour { get; set; }
            public Guid IdUser { get; set; }
            public DateTime DateCreate { get; set; }
            public DateTime DateDeadline { get; set; }
            public DateTime? DateSolved { get; set; }
            public string Describe { get; set; }
            public int IdStatus { get; set; }
            public int IdPriority { get; set; }
        }
        public void Create(CheckListGrid product, Guid idLabour)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            CheckList _checklist = new CheckList
            {
                Id = Guid.NewGuid(),
                IdLabour = idLabour,
                IdUser = product.IdUser,
                Describe = product.Describe,
                DateCreate = product.DateCreate,
                DateDeadline = product.DateDeadline,
                DateSolved = null,
                IdPriority = product.IdPriority,
                IdStatus = product.IdStatus
            };
            _elegisDbContext.CheckList.Add(_checklist);
            _elegisDbContext.SaveChanges();
        }
        public void Delete(Guid Id)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            CheckList _checklist = _elegisDbContext.CheckList.Where(x => x.Id == Id).FirstOrDefault();
            _elegisDbContext.CheckList.Remove(_checklist);
            _elegisDbContext.SaveChanges();
        }
        public void Update(CheckListGrid product, Guid Id)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            CheckList _checklist = _elegisDbContext.CheckList.Where(x => x.Id == Id).FirstOrDefault();
            if(_checklist.IdStatus!=product.IdStatus) 
            {
                if (product.IdStatus == 3)
                {
                    _checklist.DateSolved = DateTime.Now;   
                }
            }
            _checklist.DateDeadline = product.DateDeadline;
            _checklist.Describe=product.Describe;
            _checklist.IdUser = product.IdUser;
            _checklist.IdPriority = product.IdPriority;
            _elegisDbContext.SaveChanges();
        }
    }
}
