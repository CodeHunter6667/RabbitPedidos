using Microsoft.AspNetCore.Mvc;
using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.Commons;
using RabbitPedidos.Shared.DTOs;

namespace RabbitPedidos.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PedidosController(IPedidoService service, IMessageBroker broker) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CriarPedido(InsertPedidoDto dto)
    {
        var response = await service.CriarPedidoAsync(dto);
        var pendenteMessage = new PedidoPendenteDto
        {
            Id = response.Id,
            NomeCliente = response.NomeCliente,
            Descricao = response.Descricao,
            Valor = response.Valor
        };
        await broker.PublishMessage(Configurations.RABBITMQ_QUEUE_PEDIDOS,pendenteMessage);
        return CreatedAtAction(nameof(CriarPedido), response);
    }

    [HttpGet]
    public async Task<IActionResult> ObterPedidos()
    {
        var response = await service.ObterPedidos();
        return Ok(response);
    }
}
