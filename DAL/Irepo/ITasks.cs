using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepo
{
    public interface ITasks
    {
        Task AddTasks(Tasks data);
        Task<List<Task>> GetTasks();
        Task<Tasks> GetTaskbyid(int TaskID);
        Task EditTask(Tasks data);
        Task DeleteTask(int TaskID);
    }
}
