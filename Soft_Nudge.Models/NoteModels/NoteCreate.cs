using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.NoteModels
{
    public class NoteCreate
    {
        public string Entry { get; set; }
        public int ToDoId { get; set; } 
        public string DifficultyLevel { get; set; }
        public DateTimeOffset NoteCreatedDate { get; set; }
    }
}
