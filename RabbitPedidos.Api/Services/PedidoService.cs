using RabbitPedidos.Api.Repository.Interfaces;
using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.Models;

namespace RabbitPedidos.Api.Services;

public class PedidoService(IPedidoRepository repository) : BaseService<Pedido>(repository), IPedidoService
{
}
