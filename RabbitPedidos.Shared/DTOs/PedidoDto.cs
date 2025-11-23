using RabbitPedidos.Shared.Models;

namespace RabbitPedidos.Shared.DTOs;

public class PedidoDto
{
    public Guid Id { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Status { get; set; } = string.Empty;

    public PedidoDto()
    {
        
    }

    public PedidoDto(Pedido pedido)
    {
        Id = pedido.Id;
        NomeCliente = pedido.NomeCliente;
        Descricao = pedido.Descricao;
        Valor = pedido.Valor;
        Status = pedido.Status.ToString();
    }
}
