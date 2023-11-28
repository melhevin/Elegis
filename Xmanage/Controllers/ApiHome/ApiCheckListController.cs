using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xmanage.ContextModels;
using System.Linq;
using System;
using Kendo.Mvc.UI;
using Xmanage.Models.HomeMethods;
using Xmanage.Extensions;

namespace Xmanage.Controllers.ApiHome
{    
    [ApiController]
    [Route("api/apihome/apichecklist")]
    public class ApiCheckListController : ControllerBase
    {
        CheckListMethods _checklistMethods = new CheckListMethods();
        [HttpGet("ReadCheckList")]
        public async Task<IActionResult> ReadCheckList([DataSourceRequest] DataSourceRequest request, string idLabour)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            List<CheckList> listChecklist = await _elegisDbContext.CheckList.Where(x => x.IdLabour == Guid.Parse(idLabour)).ToListAsync();
            _elegisDbContext.SaveChanges();
            return Ok(listChecklist.ToDataSourceResult(request));
        }
        [HttpPost("CreateCheckList")]
        public ActionResult CreateCheckList([DataSourceRequest] DataSourceRequest request, [FromForm] CheckListMethods.CheckListGrid product, [FromForm] string idLabour)
        {
            _checklistMethods.Create(product, Guid.Parse(idLabour));
            return Ok(new[] { product }.ToDataSourceResult(request, ModelState));
        }
        [HttpPost("UpdateCheckList")]
        public ActionResult UpdateCheckList([DataSourceRequest] DataSourceRequest request, [FromForm] CheckListMethods.CheckListGrid product, [FromForm] string id)//id row of grid checklist
        {
            _checklistMethods.Create(product, Guid.Parse(id));
            return Ok(new[] { product }.ToDataSourceResult(request, ModelState));
        }
        [HttpPost("DeleteCheckList")]
        public ActionResult DeleteCheckList([DataSourceRequest] DataSourceRequest request, [FromForm] CheckListMethods.CheckListGrid product, [FromForm] string id)//id row of grid checklist
        {
            _checklistMethods.Delete(Guid.Parse(id));
            return Ok(new[] { product }.ToDataSourceResult(request, ModelState));
        }
        [HttpGet("FkGetUser")]
        public async Task<IActionResult> FkGetUser(string idLabour)
        {
            if (idLabour != null)
            {
                elegisDbContext _elegisDbContext = new elegisDbContext();
                List<Users>_Users = await _elegisDbContext.Users.Include(u => u.Workers).Where(u => u.Workers.Any(u => u.IdLabour == Guid.Parse(idLabour))).Select(u=> new Users
                {
                    Id=u.Id,
                    Name=u.Name,
                    Surname=u.Surname,
                    NameSurname=u.NameSurname,
                    Checked=u.Checked
                } ) .ToListAsync();
                _elegisDbContext.SaveChanges();
                return Ok(_Users);
            }
            else
            {
                List<Users> _Users = new List<Users>();
                return Ok(_Users);
            }
        }
    }
}
