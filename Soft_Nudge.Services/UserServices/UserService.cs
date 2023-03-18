using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Soft_Nudge.Data.Soft_NudgeContext;
using Soft_Nudge.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _ownerId;

        public UserService(ApplicationDbContext context, IHttpContextAccessor _httpContext)
        {
            _context = context;
            var userClaims = _httpContext.HttpContext!.User.Identity as ClaimsIdentity;

            var value = userClaims!.Claims.FirstOrDefault();
            _ownerId = value!.Value; //! = null-forgiving operator

            if (_ownerId == null)
            {
                throw new Exception("User is not signed in.");
            }
        }

        public async Task<UserDetailVM> GetUserDetails()
        {
            var user = await _context.AppUser.Include(a => a.UserToDos).SingleOrDefaultAsync(x => x.Id == _ownerId);
            if (user == null)
                return null;

            return new UserDetailVM
            {
                FirstName = user.FirstName,
                ToDos = user.UserToDos
            };
        }
    }
}
