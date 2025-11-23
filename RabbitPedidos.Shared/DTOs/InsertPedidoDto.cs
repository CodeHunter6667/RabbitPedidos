namespace RabbitPedidos.Shared.DTOs;

public class InsertPedidoDto
{
    public string NomeCliente { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}
