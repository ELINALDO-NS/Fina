using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fina.Api.Common.Api;
using Fina.Api.EndPoints.Categories;
using Fina.Api.EndPoints.Transaction;
using Fina.Core.Requests.Transactions;


namespace Fina.Api.EndPoints
{
    public static class EndPoint
    {
        public static void MapEndPoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/").
            WithTags("Health Check").
            MapGet("/health", () => new {Message = "Ok"} );



            endpoints.MapGroup("v1/Categories").
            WithTags("Categories").            
            MapEndPoint<CreateCategoryEndPoint>().
            MapEndPoint<UpdateCategoryEndPoint>().
            MapEndPoint<GetCategoriaByIdEndPoint>().
            MapEndPoint<GetAllCategoryEndPoint>();

            endpoints.MapGroup("v1/Transactions").
            WithTags("Transactions").           
            MapEndPoint<CreateTansactionEndPoint>().
            MapEndPoint<UpdateTansactionEndPoint>().
            MapEndPoint<GetTansactionByIdEndPoint>().
            MapEndPoint<GetTransactionByPeriodEndPoint>();


        }

        private static IEndpointRouteBuilder MapEndPoint<TEndPoint>(this IEndpointRouteBuilder app ) where TEndPoint : IEndpoint
        {
            TEndPoint.Map(app);
            return app;
        }
  
    }
}