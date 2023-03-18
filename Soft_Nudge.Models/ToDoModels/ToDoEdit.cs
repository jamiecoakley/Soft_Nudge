using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.ToDoModels
{
    public class ToDoEdit
    {
        public int Id { get; set; }

        [Required]
        public string Action { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
