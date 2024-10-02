using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;

namespace Fina.Api.EndPoints.Categories
{
    public class DeleteCategoryEmdPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapDelete("/{id}", HandleAsync).
            WithName("Categories:Delete").
            WithSummary("Deleta uma categoria").
            WithDescription("Deleta uma categoria").
            WithOrder(3).
            Produces<Response<Category>>();

        private static async Task<IResult> HandleAsync(IcategoryHandler handler, long id)
        {

            var request = new DeleteCategoryResquest()
            {
                UserId = ApisConfiguration.UserId,
                Id = id
            };
            var result = await handler.DeleteAsync(request);

            return result.IsSuccess ? TypedResults.Created($"v1/Categories/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }

    }
}
