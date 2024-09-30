using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string ConectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Fina;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
builder.Services.AddDbContext<AppDbContext>( x=> x.UseSqlServer(ConectionString)); 
builder.Services.AddTransient<IcategoryHandler, CategoryHandlers>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
