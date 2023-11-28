using Kendo.Mvc.Extensions;
using System;
using Xmanage.ContextModels;
using System.Linq;

namespace Xmanage.Models.HomeMethods
{
    public class WorkersMethods : Rights
    {
       public class WrokersGrid
        {
            public Guid Id { get; set; }
            public Guid IdLabour { get; set; }
            public Guid IdUser { get; set; }
            public bool Deleted { get; set; }
        }
        public void deleteWorker(Guid id)
        {
            elegisDbContext _elegisDbContext= new elegisDbContext();
            Workers workerDel = _elegisDbContext.Workers.Where(x => x.Id == id && x.Deleted == false).FirstOrDefault();
            workerDel.Deleted = true;
            _elegisDbContext.SaveChanges();
        }
    }
}
