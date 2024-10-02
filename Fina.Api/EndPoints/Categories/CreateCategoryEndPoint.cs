using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;

namespace Fina.Api.EndPoints.Categories
{
    public class CreateCategoryEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync).
        WithName("Categories:Create").
        WithSummary("Cria uma nova categoria").
        WithDescription("Cria uma nova categoria").
        WithOrder(1).
        Produces<Response<Category>>();

        private static async Task<IResult> HandleAsync(IcategoryHandler handler, CreateCategoryRequest request)
        {
            request.UserId = ApisConfiguration.UserId;
            var respose = await handler.CreateAsync(request);

            return respose.IsSuccess ? TypedResults.Created($"v1/Categories/{respose.Data?.Id}", respose)
                : TypedResults.BadRequest(respose);
        }



    }
}
