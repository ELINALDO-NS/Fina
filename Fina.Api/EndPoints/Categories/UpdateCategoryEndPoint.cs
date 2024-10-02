using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;

namespace Fina.Api.EndPoints.Categories
{
    public class UpdateCategoryEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapPut("/{id}", HandleAsync).
          WithName("Categories:Update").
          WithSummary("Atualiza uma categoria").
          WithDescription("Atualiza uma categoria").
          WithOrder(2).
          Produces<Response<Category>>();

        private static async Task<IResult> HandleAsync(IcategoryHandler handler, UpdateCategoryRequest request, long id)
        {


            request.UserId = ApisConfiguration.UserId;
            request.Id = id;
            
            var result = await handler.UpdateAsync(request);

            return result.IsSuccess ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
