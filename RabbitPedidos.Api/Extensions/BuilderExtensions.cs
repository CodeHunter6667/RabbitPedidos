using Microsoft.EntityFrameworkCore;
using RabbitPedidos.Api.Data;
using RabbitPedidos.Shared.Commons;

namespace RabbitPedidos.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        Configurations.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<PedidosDbContext>(options =>
        {
            options.UseMySQL(Configurations.ConnectionString);
        });
    }
}
