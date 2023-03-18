using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.ToDoModels
{
    public class ToDoCreate
    {
        [Required]
        public string Action { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }
    }
}
