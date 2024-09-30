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
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryResquest request);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request);
    }
}
