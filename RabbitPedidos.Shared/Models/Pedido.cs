using RabbitPedidos.Shared.Enums;

namespace RabbitPedidos.Shared.Models;

public class Pedido
{
    public Guid Id { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public EPedidoStatus Status { get; set; }
}
