using Fina.Api;
using Fina.Api.Common.Api;
using Fina.Api.Data;
using Fina.Api.EndPoints;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices(); 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ConfigureDevEnviroment();
}
app.UseCors(ApisConfiguration.CorsPolicyName);

app.MapEndPoints(); 

app.Run();
