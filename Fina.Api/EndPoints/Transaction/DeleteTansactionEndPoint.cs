using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fina.Api.EndPoints.Transaction
{
    public class DeleteTansactionEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapDelete("/{id}", HandleAsync).
       WithName("Transaction:Delete").
       WithSummary("Exclui uma  Transação").
       WithDescription("Exclui uma Transação").
       WithOrder(3).
       Produces<Response<Core.Model.Transaction>>();

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
        {
            var request = new DeleteTransactionRequest
            {
                Id = id,
                UserId = ApisConfiguration.UserId
            };

            var respose = await handler.DeleteAsync(request);

            return respose.IsSuccess ? TypedResults.Ok(respose)
                : TypedResults.BadRequest(respose);
        }

    }
}
