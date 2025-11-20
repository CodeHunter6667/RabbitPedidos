using RabbitPedidos.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigurations();
builder.AddDbContext();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
