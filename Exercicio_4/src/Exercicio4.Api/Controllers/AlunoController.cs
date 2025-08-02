using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
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
    public async Task<ActionResult<AlunoController>> CadastrarAluno(AlunoDto aluno)
    {
        return Created(string.Empty, await _alunoService.Cadastrar(aluno));
    }

    [HttpGet("{alunoId}")]
    public async Task<ActionResult<AlunoController>> BuscarAlunoPorId(int alunoId)
    {
        return Ok(await _alunoService.BuscarPorId(alunoId));
    }

    [HttpGet]
    public async Task<ActionResult<List<AlunoController>>> ListarAlunos()
    {
        return Ok(await _alunoService.Listar());
    }
}