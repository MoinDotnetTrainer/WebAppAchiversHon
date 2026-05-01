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
    public class TasksBl : ITasks
    {
        public readonly Appdb _db;
        public TasksBl(Appdb db)
        {
            _db = db;
        }
        public async Task AddTasks(Models.Tasks data)
        {
            await _db.Tasks.AddAsync(data);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Tasks>> GetTasks()
        {
            return await _db.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<Tasks> GetTaskbyid(int TaskID)
        {
            var res = await (from s in _db.Tasks select s).FirstOrDefaultAsync(x => x.TaskID == TaskID);
            return res;
        }

        public async Task EditTask(Tasks data)
        {
            var res = await _db.Tasks.Where(x => x.TaskID == data.TaskID).AsNoTracking().FirstOrDefaultAsync();
            // is now tracked by ef core
            var newrec = new Tasks
            {
                TaskID = res.TaskID,
                Title = data.Title,
                Description = data.Description,
                DueDate = data.DueDate,
                Status = data.Status,
                Priority = data.Priority,
            };
            _db.Tasks.Update(newrec);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteTask(int TaskID)
        {
            var res = await _db.Tasks.FindAsync(TaskID);
            if (res != null)
            {
                _db.Tasks.Remove(res);// await
                await _db.SaveChangesAsync();
            }
        }
    }
}
