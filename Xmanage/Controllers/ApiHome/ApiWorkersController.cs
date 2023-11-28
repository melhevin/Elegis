using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xmanage.ContextModels;
using Xmanage.Extensions;
using Xmanage.Models.HomeMethods;
using static Xmanage.Controllers.Home.ApiUsersController;

namespace Xmanage.Controllers.ApiHome
{
    [ApiController]
    [Route("api/apihome/apiworkers")]
    public class ApiWorkersController : ControllerBase
    {
        WorkersMethods _workersMethods = new WorkersMethods();
        [HttpGet("ReadWorkers")]
        public async Task<IActionResult> ReadWorkers([DataSourceRequest] DataSourceRequest request, string idLabour)
        {
            if (idLabour == null)
            {
                return Ok();
            }
            else
            {
                List<Workers> listWorkers = new List<Workers>();
                elegisDbContext _elegisDbContext = new elegisDbContext();
                listWorkers = await _elegisDbContext.Workers.Where(x => x.IdLabour == Guid.Parse(idLabour) && x.Deleted == false).ToListAsync();
                _elegisDbContext.SaveChanges();
                return Ok(listWorkers.ToDataSourceResult(request));
            }
        }
        public class deleteWorkerJson
        {
            public string IdWorker { get; set; }
            public string IdLabour { get; set; }
        }
        [HttpPost("DeleteWorkers")]
        public string DeleteWorkers([FromForm]string json)
        {
            deleteWorkerJson jsonWorker = JsonConvert.DeserializeObject<deleteWorkerJson>(json);
            if (_workersMethods.CreatorOfLabour(Guid.Parse(jsonWorker.IdLabour)))
            {
                _workersMethods.deleteWorker(Guid.Parse(jsonWorker.IdWorker));
                return "Spolupracovník smazán";
            }
            else
            {
                return "Nejste zakladetel tohoto úkolu.";
            }
        }
    }
}
