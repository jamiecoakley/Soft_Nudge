using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Data.Entites
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string Action { get; set; } = null!;
        public string? Description { get; set; }
        public string OwnerId { get; set; } = null!;
        
        [ForeignKey(nameof(OwnerId))]
        public AppUser AppUser { get; set; } = null!;
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
        public List<Note> ToDoEntries { get; set; } = new List<Note>();

    }
}
