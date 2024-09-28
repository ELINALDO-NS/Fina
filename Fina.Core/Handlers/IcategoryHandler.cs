using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Handlers
{
    public interface IcategoryHandler
    {
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest createCategory);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest updateCategory);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryResquest deleteCategory);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest getCategoryById);
        Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest getAllCategories);
    }
}
