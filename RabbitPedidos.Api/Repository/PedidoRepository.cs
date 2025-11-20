using RabbitPedidos.Api.Data;
using RabbitPedidos.Api.Repository.Interfaces;
using RabbitPedidos.Shared.Models;

namespace RabbitPedidos.Api.Repository;

public class PedidoRepository(PedidosDbContext context) : BaseRepository<Pedido>(context), IPedidoRepository
{
}
