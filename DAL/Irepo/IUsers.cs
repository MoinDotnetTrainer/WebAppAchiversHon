using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepo
{
    public interface IUsers
    {
        Task AddUsers(Users data);
        Task<bool> LoginUsers(LoginModel logindata);
    }
}
