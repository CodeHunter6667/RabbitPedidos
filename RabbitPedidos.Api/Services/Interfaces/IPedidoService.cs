using RabbitPedidos.Shared.DTOs;
using RabbitPedidos.Shared.Models;

namespace RabbitPedidos.Api.Services.Interfaces;

public interface IPedidoService : IBaseService<Pedido>
{
    Task<PedidoDto> CriarPedidoAsync(InsertPedidoDto dto);
    Task<IEnumerable<PedidoDto>> ObterPedidos();
}
