using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Fina.Api.Handlers
{
    public class CategoryHandlers(AppDbContext Context) : IcategoryHandler
    {

        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category()
            {
                Description = request.Description,
                Title = request.Title,
                UserId = request.UserId
            };
            try
            {
                await Context.Categories.AddAsync(category);
                await Context.SaveChangesAsync();

            }
            catch (DbException bdex)
            {
                Console.WriteLine(bdex.Message);
                throw;
            }  
            catch (Exception ex)
            {

               Console.WriteLine(ex.ToString());
                throw;
            }
            return new Response<Category>(category,201,null);
        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryResquest request)
        {
            try
            {
                var category = await Context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
                if (category == null)
                {

                    return new Response<Category?>(null, 404, "Categoria Não encontrada");
                }

               Context.Categories.Remove(category);
                await Context.SaveChangesAsync();
                return new Response<Category?>(category, Message: "Categoria Excluida");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
        {
            try
            {
                var query = Context.Categories.AsNoTracking().
                    Where(x => x.UserId == request.UserId).
                    OrderBy(x => x.Title);

                var categories = await query.
                    Skip((request.PageNumber -1) * request.PageZise).
                    Take(request.PageZise).
                    ToListAsync();
                var count = await query.CountAsync();
                return new PagedResponse<List<Category>?>(categories,count, request.PageNumber, request.PageZise);

            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Category>?>(null,500,"Não foi possivel obter as categorias !");              
                throw;

            }
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await Context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
                if (category is null)
                {
                    return new Response<Category?>(null,404,"Categoria Não Encontrada !");
                }
                return new Response<Category?>(category);
            }
            catch (Exception ex)
            {
                return new Response<Category?>(null, 500, "Não foi possivel retornar a categoria !");
            
            throw;
            }
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await Context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
                if (category == null)
                {
                   
                    return new Response<Category?>(null,404, "Categoria Não encontrada");
                }
               
                category.Title = request.Title;
                category.Description = request.Description;
                Context.Categories.Update(category);
               await Context.SaveChangesAsync();
                return new Response<Category?>(category, Message: "Categoria Atualizada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
