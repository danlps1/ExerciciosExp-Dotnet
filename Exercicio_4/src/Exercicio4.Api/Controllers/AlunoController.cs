using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpPost]
    public async Task<ActionResult<Aluno>> CadastrarAluno(AlunoDto aluno)
    {
        return Created(string.Empty, await _alunoService.Cadastrar(aluno));
    }
    
    [HttpGet("historico")]
    public async Task<ActionResult<List<Aluno>>> ExibirHistoricoAluno([FromQuery] int? alunoId)
    {
        if (alunoId == null)
        {
            return Ok(await _alunoService.Listar());
        }

        return Ok(await _alunoService.BuscarPorId(alunoId));
    }
}