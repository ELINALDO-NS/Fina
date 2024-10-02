using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;

namespace Fina.Api.EndPoints.Transaction
{
    public class UpdateTansactionEndPoint:IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapPut("/{id}", HandleAsync).
          WithName("Transactions:Update").
          WithSummary("Atualiza uma transação").
          WithDescription("Atualiza uma transação").
          WithOrder(2).
          Produces<Response<Core.Model.Transaction>>();

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, UpdateTransactionRequest request, long id)
        {


            request.UserId = ApisConfiguration.UserId;
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
