using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.Commons;
using RabbitPedidos.Shared.DTOs;
using RabbitPedidos.Shared.Extensions;

namespace RabbitPedidos.Api.Listeners;

public class PedidoListener(IMessageBroker broker, IServiceScopeFactory scopeFactory)
{
    public async Task UpdatePedido(PedidoPendenteDto dto)
    {
        using var scope = scopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IPedidoService>();

        await Task.Delay(15000);

        var pedido = dto.MapPendingToEntity();
        await service.Update(pedido);
    }

    public async void StartListening()
    {
        await broker.SubscribeMessage<PedidoPendenteDto>(Configurations.RABBITMQ_QUEUE_PEDIDOS, UpdatePedido);
    }
}
