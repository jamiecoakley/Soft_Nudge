using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.NoteModels
{
    public class NoteEdit
    {
        public int Id { get; set; }
        [Required]
        public string Entry { get; set; }
        [Required]
        public string DifficultyLevel { get; set; }
        public DateTimeOffset NoteCreatedDate { get; set; }

        public DateTimeOffset NoteModifiedDate { get; set; }
    }
}
