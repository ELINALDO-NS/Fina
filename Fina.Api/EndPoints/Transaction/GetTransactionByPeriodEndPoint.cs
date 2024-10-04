using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;
using Fina.Core;
using Microsoft.AspNetCore.Mvc;
using Fina.Core.Requests.Transactions;

namespace Fina.Api.EndPoints.Transaction
{
    public class GetTransactionByPeriodEndPoint:IEndpoint
    {

        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync).
            WithName("Transaction:Get All").
            WithSummary("Retorna todas as Transaction").
            WithDescription("Retorna todas as Transaction").
            WithOrder(5).
            Produces<PagedResponse<Core.Model.Transaction>>();



        private static async Task<IResult> HandleAsync(ITransactionHandler handler,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? enDdate = null,
            [FromQuery] int pagenumber = Configuration.DefaultPageNumeber,
            [FromQuery] int pagesize = Configuration.DefaultPageSize
            )
        {
            var request = new GetTransactionsByPeriodRequest()
            {
                UserId = ApisConfiguration.UserId,
                PageNumber = pagenumber,
                PageZise = pagesize,
                StatDate = startDate,
                EndDate = enDdate,
                
            };

            request.UserId = ApisConfiguration.UserId;
            var result = await handler.GetByPeriodAsync(request);

            return result.IsSuccess ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
