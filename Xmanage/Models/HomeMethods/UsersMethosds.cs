using Kendo.Mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using Xmanage.ContextModels;

namespace Xmanage.Models.HomeMethods
{
    public class UsersMethosds : Rights
    {
        public class UsersGrid
        {
            public Guid? Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public bool Checked { get; set; }
            public string NameSurname { get; set; }
        }
        public async void Create(UsersGrid product)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            Users _User = new Users
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Surname = product.Surname,
                NameSurname= product.Name + " " + product.Surname,
                Checked = true
            };
            UsersToFalse();
            await _elegisDbContext.Users.AddAsync(_User);
            _elegisDbContext.SaveChanges();
        }
        public async void Update(UsersGrid product)
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            if (product.Checked == true)
            {
                UsersToFalse();
            }
            var _user = await _elegisDbContext.Users.FirstOrDefaultAsync(x => x.Id == product.Id);
            _user.Name = product.Name;
            _user.Surname = product.Surname;
            _user.Checked = product.Checked;
            _user.NameSurname = product.Name + " " + product.Surname;
            _elegisDbContext.SaveChanges();
        }
        private async void UsersToFalse()
        {
            elegisDbContext _elegisDbContext = new elegisDbContext();
            var _users = await _elegisDbContext.Users.ToListAsync();
            foreach (var user in _users)
            {
                user.Checked = false;
            }
            _elegisDbContext.SaveChanges();
        }
    }
}
