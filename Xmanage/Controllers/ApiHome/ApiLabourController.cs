using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Xmanage.ContextModels;
using Xmanage.Models.HomeMethods;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Xmanage.Extensions;
using Newtonsoft.Json;
using System.Security.Principal;
using static Xmanage.Models.HomeMethods.LabourMethods;

namespace Xmanage.Controllers.ApiHome
{
    [ApiController]
    [Route("api/apihome/apilabour")]
    public class ApiLabourController : ControllerBase
    {
        LabourMethods _labourMethods = new LabourMethods();
        [HttpGet("ReadLabour")]
        public async Task<IActionResult> ReadLabour([DataSourceRequest] DataSourceRequest request)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            List<Labour> listLabour = await _elegisDbContext.Labour.ToListAsync();
            _elegisDbContext.SaveChanges();
            return Ok(listLabour.ToDataSourceResult(request));
        }
        [HttpPost("CreateDefaultLabour")]
        public IActionResult CreateDefaultLabour()
        {
            Guid id = _labourMethods.CreateDefault();
            return Ok(id);
        }
        [HttpPost("DeleteDefaultLabour")]
        public IActionResult DeleteDefaultLabour([FromForm] string idLabour)
        {
            _labourMethods.DeleteDefault(Guid.Parse(idLabour));
            return Ok();
        }

        [HttpPost("SaveDefaultLabour")]
        public IActionResult SaveDefaultLabour([FromBody] labourForm _labourForm)
        {
            _labourMethods.SaveDefault(_labourForm);
            return Ok();
        }
        //[HttpGet("FK_IdPriority")]
        //public IActionResult FK_IdPriority()
        //{
        //    elegisDbContext _elegisDbContext = new elegisDbContext();
        //    var company = _elegisDbContext.Priority.Select(x => x);
        //    _elegisDbContext.SaveChanges();
        //    return Ok(company);
        //}
        //[HttpGet("FK_IdStatus")]
        //public IActionResult FK_IdStatus()
        //{
        //    elegisDbContext _elegisDbContext = new elegisDbContext();
        //    var company = _elegisDbContext.Status.Select(x => x);
        //    _elegisDbContext.SaveChanges();
        //    return Ok(company);
        //}
        [HttpGet("FkGetPriority")]
        public async Task<IActionResult> FkGetPriority()
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            List<Priority> _Priority = await _elegisDbContext.Priority.ToListAsync();
            _elegisDbContext.SaveChanges();
            return Ok(_Priority);
        }
        [HttpGet("FkGetStatus")]
        public async Task<IActionResult> FkGetStatus()
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            List<Status> _Status = await _elegisDbContext.Status.ToListAsync();
            _elegisDbContext.SaveChanges();
            return Ok(_Status);
        }
        [HttpGet("FkGetUser")]
        public async Task<IActionResult> FkGetUser()
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            List<Users> _Users = await _elegisDbContext.Users.ToListAsync();
            _elegisDbContext.SaveChanges();
            return Ok(_Users);
        }
        [HttpPost("GetUser")]
        public IActionResult GetUser([FromForm]Guid id)
        {
            Users user= new Users();
            elegisDbContext _elegisDbContext = new elegisDbContext();
            user = user.GetUser(_elegisDbContext, id);
            _elegisDbContext.SaveChanges();
            return Ok(user);
        }
    }
}
