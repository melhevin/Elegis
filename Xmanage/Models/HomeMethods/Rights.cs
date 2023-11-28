using Kendo.Mvc.Extensions;
using System;
using Xmanage.ContextModels;
using Xmanage.Extensions;
using System.Linq;

namespace Xmanage.Models.HomeMethods
{
    public class Rights
    {
        public bool CreatorOfLabour(Guid idLabour)//jenom tvurce ukolu ho muze upravovat
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            Users user = new Users();
            user = user.GetLoginUser(_elegisDbContext);
            Labour _labour = _elegisDbContext.Labour.Where(x => x.Id == idLabour && x.IdUser == user.Id).FirstOrDefault();
            if (_labour != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
