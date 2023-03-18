using Soft_Nudge.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(CategoryCreate model);
        Task<bool> UpdateCategory(CategoryEdit model);
        Task<CategoryDetail> GetCategory(int id);
        Task<List<CategoryDetail>> GetCategories();
        Task<List<CategoryListItem>> GetCategoryList();
        Task<bool> DeleteCategory(int id);


    }
}
