using Soft_Nudge.Data.Entites;
using Soft_Nudge.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.ToDoModels
{
    public class ToDoDetail
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public CategoryListItem Category { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
