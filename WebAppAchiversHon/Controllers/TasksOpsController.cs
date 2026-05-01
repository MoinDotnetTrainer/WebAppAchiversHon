using DAL.Irepo;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAchiversHon.Controllers
{
    public class TasksOpsController : Controller
    {
        public readonly ITasks _itask;
        public TasksOpsController(ITasks itask)
        {
            _itask = itask;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tasks data)
        {
            if (ModelState.IsValid)
            {
                await _itask.AddTasks(data);
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> Index()
        {
            var res = await _itask.GetTasks();
            return View(res);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int TaskID)
        {
            var res = await _itask.GetTaskbyid(TaskID);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tasks data)
        {
            if (ModelState.IsValid)
            {
                await _itask.EditTask(data);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int TaskID)
        {
            var res = await _itask.GetTaskbyid(TaskID);
            return View(res);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int TaskID)
        {
            await _itask.DeleteTask(TaskID);
            return RedirectToAction("Index");
        }
    }
}
