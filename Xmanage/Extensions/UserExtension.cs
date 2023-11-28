using Kendo.Mvc.Extensions;
using Xmanage.ContextModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Xmanage.Extensions
{
    public static class UserExtension
    {
        public static Users GetLoginUser(this Users user, elegisDbContext _elegisDbContext)
        {
            user = _elegisDbContext.Users.Where(x => x.Checked == true).FirstOrDefault();
            return user;
        }
        public static Users GetUser(this Users user, elegisDbContext _elegisDbContext, Guid id)
        {
            user = _elegisDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }
    }
}
