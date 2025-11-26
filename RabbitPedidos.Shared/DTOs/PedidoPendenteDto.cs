using RabbitPedidos.Shared.Enums;

namespace RabbitPedidos.Shared.DTOs;

public class PedidoPendenteDto
{
    public Guid Id { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}
