using Microsoft.EntityFrameworkCore;
using RabbitPedidos.Api.Data;
using RabbitPedidos.Api.Listeners;
using RabbitPedidos.Api.Repository;
using RabbitPedidos.Api.Repository.Interfaces;
using RabbitPedidos.Api.Services;
using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.Commons;

namespace RabbitPedidos.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        Configurations.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configurations.RABBITMQ_HOSTNAME = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
        Configurations.RABBITMQ_USERNAME = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? "guest";
        Configurations.RABBITMQ_PASSWORD = Environment.GetEnvironmentVariable("RABBITMQ_PASS") ?? "guest";

        Console.WriteLine($"Host do Rabbitmq: {Configurations.RABBITMQ_HOSTNAME}");
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<PedidosDbContext>(options =>
        {
            options.UseMySQL(Configurations.ConnectionString);
        });
    }

    public static void AddRepositories(this WebApplicationBuilder builder1)
    {
        builder1.Services.AddScoped<IPedidoRepository, PedidoRepository>();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPedidoService, PedidoService>();
        builder.Services.AddSingleton<PedidoListener>();
    }

    public static void AddMessageBroker(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMessageBroker, MessageBroker>();
    }
}
