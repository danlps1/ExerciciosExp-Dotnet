using Exercicio_3.Entities;
using Exercicio_3.Services.Dtos;
using Exercicio_3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio_3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarcaController : ControllerBase
{
    private readonly IMarcaService _marcaService;

    public MarcaController(IMarcaService marcaService)
    {
        _marcaService = marcaService;
    }

    [HttpPost]
    public async Task<ActionResult<Marca>> CadastrarMarca(MarcaDto marca)
    {
        return Created(string.Empty, await _marcaService.CadastrarMarca(marca));
    }

    [HttpGet("/{marcaId}")]
    public async Task<ActionResult<Marca>> BuscarMarcaPorId(int marcaId)
    {
        return Ok(await _marcaService.BuscarMarcaPordId(marcaId));
    }
}