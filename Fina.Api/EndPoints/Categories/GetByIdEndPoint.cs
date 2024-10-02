using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;

namespace Fina.Api.EndPoints.Categories
{
    public class GetByIdEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapGet("/{id}", HandleAsync).
          WithName("Categories:Get BY Id").
          WithSummary("Retorna uma categoria").
          WithDescription("Retorna uma categoria").
          WithOrder(4).
          Produces<Response<Category>>();

        private static async Task<IResult> HandleAsync(IcategoryHandler handler, long id)
        {

            var request = new GetCategoryByIdRequest()
            {
                UserId = ApisConfiguration.UserId,
                Id = id
            };
            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
