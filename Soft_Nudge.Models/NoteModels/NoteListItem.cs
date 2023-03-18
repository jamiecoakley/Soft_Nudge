using Soft_Nudge.Models.ToDoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.NoteModels
{
    public class NoteListItem
    {
        public ToDoListItem ToDo { get; set; }
        public string Entry { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
