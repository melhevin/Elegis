using Kendo.Mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using Xmanage.ContextModels;
using Xmanage.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace Xmanage.Models.HomeMethods
{
    public class LabourMethods : Rights
    {
        public class LabourGrid
        {
            public Guid? Id { get; set; }
            public string Company { get; set; }
            public Guid? IdUser { get; set; }
            public string Describe { get; set; }
            public DateTime DateCreate { get; set; }
            public DateTime DateDeadline { get; set; }
            public DateTime? DateSolved { get; set; }
            public int IdPriority { get; set; }
            public int IdStatus { get; set; }
        }
        public class labourForm
        {
            public string Company { get; set; }
            public string Describe { get; set; }
            public DateTime DateDeadline { get; set; }
            public string IdPriority { get; set; }
            public string IdStatus { get; set; }
            public string IdLabour { get; set; }
        }

        public void Create(LabourGrid product)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            Users user = new Users();
            user = user.GetLoginUser(_elegisDbContext);
            Labour _labour = new Labour
            {
                Id = Guid.NewGuid(),
                Company = product.Company,
                IdUser = user.Id,
                Describe = product.Describe,
                DateCreate = product.DateCreate,
                DateDeadline = product.DateDeadline,
                IdPriority = product.IdPriority,
                IdStatus = product.IdStatus
            };
            _elegisDbContext.Labour.Add(_labour);
            _elegisDbContext.SaveChanges();
        }
        public Guid CreateDefault()
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            Users user = new Users();
            user = user.GetLoginUser(_elegisDbContext);
            Guid id = Guid.NewGuid();
            Labour _labour = new Labour
            {
                Id = id,
                Company = "",
                IdUser = user.Id,
                Describe = "",
                DateCreate = DateTime.Now,
                DateDeadline = DateTime.Now,
                IdPriority = 1,
                IdStatus = 1
            };
            _elegisDbContext.Labour.Add(_labour);
            _elegisDbContext.SaveChanges();
            return id;
        }
        public void DeleteDefault(Guid idLabour)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            Labour _labour = _elegisDbContext.Labour.Where(x => x.Id == idLabour).FirstOrDefault();
            List<Workers> _listWorkers= _elegisDbContext.Workers.Where(x => x.IdLabour==idLabour).ToList();
            List<CheckList> _listChecklist= _elegisDbContext.CheckList.Where(x => x.IdLabour==idLabour).ToList();
            List<Chat> _listChat=_elegisDbContext.Chat.Where(x => x.IdLabour == idLabour).ToList();
            foreach(var rec in _listWorkers)
            {
                _elegisDbContext.Workers.Remove(rec);
            }
            foreach (var rec in _listChecklist)
            {
                _elegisDbContext.CheckList.Remove(rec);
            }
            foreach (var rec in _listChat)
            {
                _elegisDbContext.Chat.Remove(rec);
            }
            _elegisDbContext.Labour.Remove(_labour);
            _elegisDbContext.SaveChanges();
        }
        public void SaveDefault(labourForm _labourForm )
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            Labour _labour = _elegisDbContext.Labour.Where(x => x.Id == Guid.Parse(_labourForm.IdLabour)).FirstOrDefault();
            _labour.Company= _labourForm.Company;
            _labour.Describe = _labourForm.Describe;
            _labour.DateDeadline = _labourForm.DateDeadline;
            _labour.IdPriority = Convert.ToInt16(_labourForm.IdPriority);
            _labour.IdStatus = Convert.ToInt16(_labourForm.IdStatus);
            _elegisDbContext.SaveChanges();
        }
    }
}
