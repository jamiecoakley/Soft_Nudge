using Soft_Nudge.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Models.UserModels
{
    public class UserDetailVM
    {
        public string FirstName { get; set; } = null!;
        public List<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}
