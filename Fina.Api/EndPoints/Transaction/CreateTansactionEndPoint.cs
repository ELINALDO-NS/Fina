using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Model;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;

namespace Fina.Api.EndPoints.Transaction
{
    public class CreateTansactionEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapPost("/", HandleAsync).
       WithName("Transaction:Create").
       WithSummary("Cria uma nova Transação").
       WithDescription("Cria uma nova Transação").
       WithOrder(1).
       Produces<Response<Core.Model.Transaction>>();

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, CreateTransactionRequest request)
        {
           
            request.UserId = ApisConfiguration.UserId;
            var respose = await handler.CreateAsync(request);

            return respose.IsSuccess ? TypedResults.Created($"v1/Categories/{respose.Data?.Id}", respose)
                : TypedResults.BadRequest(respose);
        }

    }
}
