using Microsoft.EntityFrameworkCore;
using RabbitPedidos.Api.Data;
using RabbitPedidos.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigurations();
builder.AddDbContext();
builder.AddRepositories();
builder.AddServices();
builder.AddMessageBroker();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PedidosDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.StartListener();

app.Run();
