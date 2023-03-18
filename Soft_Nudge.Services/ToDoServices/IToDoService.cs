using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft_Nudge.Models.ToDoModels;

namespace Soft_Nudge.Services.ToDoServices
{
    public interface IToDoService
    {
        Task<bool> CreateToDo(ToDoCreate model);
        Task<bool> UpdateToDo(ToDoEdit model);
        Task<bool> DeleteToDo(int id);
        Task<ToDoDetail> GetToDo(int id);
        Task<List<ToDoDetail>> GetToDosList();
        Task<ToDoListItem> GetRandomToDo();
    }
}
