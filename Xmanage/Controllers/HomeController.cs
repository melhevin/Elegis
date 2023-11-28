using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xmanage.ContextModels;
using Xmanage.Models;
using Xmanage.Models.HomeMethods;

namespace Xmanage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            List<Priority> listPriority = await _elegisDbContext.Priority.ToListAsync();
            List<Status> listStatus = await _elegisDbContext.Status.ToListAsync();
            List<Users> listUsers = await _elegisDbContext.Users.ToListAsync();
            _elegisDbContext.SaveChanges();
            ViewBag.Priority = listPriority;
            ViewBag.Status = listStatus;
            ViewBag.Users = listUsers;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async void ImportFromSandbox(string btnImportFromSandbox)
        {
            Response.Redirect("/home");
        }
    }
}
