using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;
using Microsoft.AspNetCore.Mvc;
using Fina.Core;

namespace Fina.Api.EndPoints.Categories
{
    public class GetAllCategoryEndPoint : IEndpoint
    {

        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync).
            WithName("Categories:Get All").
            WithSummary("Retorna todas as categorias").
            WithDescription("Retorna todas as categorias").
            WithOrder(5).
            Produces<PagedResponse<Category>>();



        private static async Task<IResult> HandleAsync(IcategoryHandler handler,
            [FromQuery] int pagenumber = Configuration.DefaultPageNumeber,
            [FromQuery] int pagesize = Configuration.DefaultPageSize
            )
        {
            var request = new GetAllCategoriesRequest()
            {
                UserId = ApisConfiguration.UserId,
                PageNumber = pagenumber,
                PageZise = pagesize
            };

            request.UserId = ApisConfiguration.UserId;
            var result = await handler.GetAllAsync(request);

            return result.IsSuccess ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
