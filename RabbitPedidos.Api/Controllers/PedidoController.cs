using Microsoft.AspNetCore.Mvc;
using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.DTOs;

namespace RabbitPedidos.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PedidoController(IPedidoService service) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CriarPedido(InsertPedidoDto dto)
    {
        var response = await service.CriarPedidoAsync(dto);
        return CreatedAtAction(nameof(CriarPedido), response);
    }

    [HttpGet]
    public async Task<IActionResult> ObterPedidos()
    {
        var response = await service.ObterPedidos();
        return Ok(response);
    }
}
