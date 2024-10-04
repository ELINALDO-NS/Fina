using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fina.Api.Common.Api
{
    public static class BuilderExtension
    {
       public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ApisConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackEndUrl = builder.Configuration.GetValue<string>("BackEndUrl") ?? string.Empty;
            Configuration.FrontEndUrl = builder.Configuration.GetValue<string>("FrontEndUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddDataContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(ApisConfiguration.ConnectionString ));
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(x => x.AddPolicy(ApisConfiguration.CorsPolicyName,
                policy => policy.WithOrigins(Configuration.BackEndUrl, Configuration.FrontEndUrl).
                AllowAnyMethod().
                AllowAnyHeader()
               .AllowCredentials()
                ));

        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IcategoryHandler, CategoryHandlers>();
            builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

        }
    }
}
