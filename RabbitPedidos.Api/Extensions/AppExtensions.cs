using RabbitPedidos.Api.Listeners;

namespace RabbitPedidos.Api.Extensions;

public static class AppExtensions
{
    public static void StartListener(this WebApplication app)
    {
        var pedidoListener = app.Services.GetRequiredService<PedidoListener>();
        pedidoListener.StartListening();
    }
}
