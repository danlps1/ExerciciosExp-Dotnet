using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpPost]
    public async Task<ActionResult<Grade>> CadastrarGrade(GradeDto grade)
    {
        return Created(string.Empty, await _gradeService.Cadastrar(grade));
    }

    [HttpGet("{gradeId}")]
    public async Task<ActionResult<Grade>> BuscarGradePorId(int gradeId)
    {
        return Ok(await _gradeService.BuscarPorId(gradeId));
    }

    [HttpGet]
    public async Task<ActionResult<List<Grade>>> ListarGrades()
    {
        return Ok(await _gradeService.Listar());
    }
}