using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Data.Entites
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public List<ToDo> ToDosByCategory { get; set; } = new List<ToDo>();

        public string? OwnerId { get; set; } 

        [ForeignKey(nameof(OwnerId))]
        public AppUser? AppUser { get; set; }

    }
}
