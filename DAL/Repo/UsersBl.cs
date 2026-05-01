using DAL.Irepo;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UsersBl : IUsers
    {
        public readonly Appdb _db;
        public UsersBl(Appdb db)
        {
            _db = db;
        }

        public async Task AddUsers(Users data)
        {
            await _db.Users.AddAsync(data);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> LoginUsers(LoginModel logindata)
        {
            var res = await _db.Users.AnyAsync(x => x.Email == logindata.Email && x.Password == logindata.Password);
            return res;
        }
    }
}
