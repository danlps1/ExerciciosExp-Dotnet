using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotaController : ControllerBase
{
    private readonly INotaService _notaService;

    public NotaController(INotaService notaService)
    {
        _notaService = notaService;
    }

    [HttpPost]
    public async Task<ActionResult<List<Nota>>> CadastrarNota(NotaDto nota)
    {
        return Created(string.Empty, await _notaService.Cadastrar(nota));
    }
}