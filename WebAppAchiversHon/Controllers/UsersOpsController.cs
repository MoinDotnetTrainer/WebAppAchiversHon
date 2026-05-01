using DAL.Irepo;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAchiversHon.Controllers
{
    public class UsersOpsController : Controller
    {

        public readonly IUsers _iuser;
        public UsersOpsController(IUsers iuser)
        {
            _iuser = iuser;
        }


        [HttpGet]
        public IActionResult AddUsers()  // auto generated views
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(Users data)
        {
            if (ModelState.IsValid)
            {
                await _iuser.AddUsers(data);
                return RedirectToAction("LoginUsers");
            }
            else
                return View();

        }

        [HttpGet]
        public IActionResult LoginUsers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUsers(LoginModel data)
        {
            if (ModelState.IsValid)
            {
                await _iuser.LoginUsers(data);
                return RedirectToAction("Homepage");
            }
            else
            { return View(); }

        }

        public IActionResult Homepage()
        {
            return View();
        }
    }
}
