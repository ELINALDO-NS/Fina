using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;

namespace Fina.Api.EndPoints.Transaction
{
    public class GetTansactionByIdEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync).
        WithName("Transaction:Get BY Id").
        WithSummary("Retorna uma Transação").
        WithDescription("Retorna uma Transação").
        WithOrder(4).
        Produces<Response<Core.Model.Transaction>>();

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
        {

            var request = new GetTransactionByIdRequest()
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
