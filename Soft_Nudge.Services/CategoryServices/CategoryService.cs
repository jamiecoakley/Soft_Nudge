using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Soft_Nudge.Data.Entites;
using Soft_Nudge.Data.Soft_NudgeContext;
using Soft_Nudge.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private string _ownerId;

        public CategoryService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;

            var userClaims = httpContext.HttpContext!.User.Identity as ClaimsIdentity;
            var value = userClaims!.Claims.FirstOrDefault();

            _ownerId = value!.Value;
            if (_ownerId is null)
            {
                throw new Exception("User is not signed in.");
            }
        }

        public void SetOwnerId(string ownerId)
        { _ownerId = ownerId; }

        public async Task<bool> CreateCategory(CategoryCreate model)
        {
            var category = _mapper.Map<Category>(model);
            category.OwnerId = _ownerId;
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<CategoryDetail>> GetCategories()
        {
            var categories = await _context.Categories.Where(x => x.OwnerId == _ownerId).ToListAsync();
            return _mapper.Map<List<CategoryDetail>>(categories);
        }

        public async Task<List<CategoryListItem>> GetCategoryList()
        {
            var categories = await _context.Categories.Where(x => x.OwnerId == _ownerId).ToListAsync();
            return _mapper.Map<List<CategoryListItem>>(categories);
        }

        public async Task<CategoryDetail> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
            { return new CategoryDetail(); }

            return _mapper.Map<CategoryDetail>(category);
        }

        public async Task<bool> UpdateCategory(CategoryEdit model)
        {
            var category = await _context.Categories.FindAsync(model.Id);
            if (category is null) 
            { return false;}

            category.Name = model.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.Where(x => x.OwnerId == _ownerId).SingleOrDefaultAsync(y => y.Id == id);

            if (category is null)
            { return false; }

            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
