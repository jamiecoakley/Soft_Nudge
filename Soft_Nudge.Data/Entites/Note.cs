using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Data.Entites
{
    public class Note
    {
        public int Id { get; set; }
        public string Entry { get; set; } = null!;
        public string DifficultyLevel { get; set; }=null!;
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public AppUser AppUser { get; set; } = null!;
        public int ToDoId { get; set; }

        [ForeignKey(nameof(ToDoId))]
        public virtual ToDo ToDo { get; set; } = null!;
        public DateTimeOffset NoteCreatedDate { get; set; }
        public DateTimeOffset? NoteModifiedDate { get; set; }
    }
}
