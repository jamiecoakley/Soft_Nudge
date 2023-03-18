using Soft_Nudge.Models.ToDoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.CategoryModels
{
    public class CategoryDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoListItem> ToDosByCategory { get; set; } = new List<ToDoListItem>();
    }
}
