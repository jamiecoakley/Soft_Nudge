using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Data.Entites
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public List<ToDo> UserToDos { get; set; } = new List<ToDo>();
        public List<Note> Notes { get; set; } = new List<Note>();

    }
}
