using RabbitPedidos.Shared.DTOs;
using RabbitPedidos.Shared.Enums;
using RabbitPedidos.Shared.Models;

namespace RabbitPedidos.Shared.Extensions;

public static class PedidoExtension
{
    public static Pedido MapToPedido(this InsertPedidoDto dto)
    {
        return new Pedido
        {
            Id = Guid.NewGuid(),
            NomeCliente = dto.NomeCliente,
            Descricao = dto.Descricao,
            Valor = dto.Valor,
            Status = EPedidoStatus.Processado
        };
    }

    public static PedidoDto MapToPedidoDto(this Pedido pedido)
    {
        return new PedidoDto
        {
            Id = pedido.Id,
            NomeCliente = pedido.NomeCliente,
            Descricao = pedido.Descricao,
            Valor = pedido.Valor,
            Status = pedido.Status.ToString()
        };
    }
}
