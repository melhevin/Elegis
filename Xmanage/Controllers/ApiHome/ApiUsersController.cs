using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Xmanage.ContextModels;
using Xmanage.Extensions;
using System.Text.Encodings.Web;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xmanage.Models.HomeMethods;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Xmanage.Controllers.Home
{  
    [ApiController]
    [Route("api/apihome/apiusers")]
    public class ApiUsersController : ControllerBase
    {
        UsersMethosds _usersMethosds = new UsersMethosds();
        [HttpGet("ReadUsers")]
        public async Task<IActionResult> ReadUsers([DataSourceRequest] DataSourceRequest request)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            List<Users> listUsers = await _elegisDbContext.Users.ToListAsync();
            _elegisDbContext.SaveChanges();
            return Ok(listUsers.ToDataSourceResult(request));
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([DataSourceRequest] DataSourceRequest request,[FromForm] UsersMethosds.UsersGrid product)
        {
            if (product != null && product.Name != null && product.Surname != null)
            {
                _usersMethosds.Create(product);
                return Ok(new[] { product }.ToDataSourceResult(request));
            }
            else
            {
                return Ok(null);
            }
        }
        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser([DataSourceRequest] DataSourceRequest request,[FromForm] UsersMethosds.UsersGrid product)
        {
            _usersMethosds.Update(product);
            return Ok(new[] { product }.ToDataSourceResult(request));
        }
        public  class addWorkerJson
        {
            public string IdUser { get; set; }
            public string IdLabour { get; set;}
        }
        [HttpPost("AddWorker")]
        public IActionResult AddWorker([FromForm]string json)
        {
            addWorkerJson _addWorker = JsonConvert.DeserializeObject<addWorkerJson>(json);
            elegisDbContext _elegisDbContext = new elegisDbContext();
            Users user = new Users();
            user = user.GetUser(_elegisDbContext, Guid.Parse(_addWorker.IdUser));
            Workers workerExist = _elegisDbContext.Workers.Where(x => x.IdLabour == Guid.Parse(_addWorker.IdLabour) && x.IdUser == Guid.Parse(_addWorker.IdUser)).FirstOrDefault();
            if (workerExist != null)
            {
                workerExist.Deleted = false;
            }
            else
            {
                Workers worker = new Workers()
                {
                    Id = Guid.NewGuid(),
                    IdLabour = Guid.Parse(_addWorker.IdLabour),
                    IdUser = Guid.Parse(_addWorker.IdUser)
                };
                _elegisDbContext.Workers.Add(worker);
            }
            _elegisDbContext.SaveChanges();
            return Ok();
        }
    }
}
