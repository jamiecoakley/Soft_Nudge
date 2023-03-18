using Soft_Nudge.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.UserServices
{
    public interface IUserService
    {
        Task<UserDetailVM> GetUserDetails();
    }
}
