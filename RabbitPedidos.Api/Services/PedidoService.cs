using RabbitPedidos.Api.Repository.Interfaces;
using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.DTOs;
using RabbitPedidos.Shared.Extensions;
using RabbitPedidos.Shared.Models;

namespace RabbitPedidos.Api.Services;

public class PedidoService(IPedidoRepository repository) : BaseService<Pedido>(repository), IPedidoService
{
    public async Task<PedidoDto> CriarPedidoAsync(InsertPedidoDto dto)
    {
        var pedido = dto.MapToPedido();
        await repository.Insert(pedido);
        return new PedidoDto(pedido);
    }
}
