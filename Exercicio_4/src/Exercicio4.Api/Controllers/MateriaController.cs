using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MateriaController : ControllerBase
{
    private readonly IMateriaService _materiaService;

    public MateriaController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [HttpPost]
    public async Task<ActionResult<Materia>> CadastrarMateria(MateriaDto materia)
    {
        return Created(string.Empty, await _materiaService.Cadastrar(materia));
    }

    [HttpGet("{materiaId}")]
    public async Task<ActionResult<Materia>> BuscarMateriaPorId(int materiaId)
    {
        return Ok(await _materiaService.BuscarPorId(materiaId));
    }

    [HttpGet]
    public async Task<ActionResult<List<Materia>>> ListarMaterias() 
    {
        return Ok(await _materiaService.Listar());
    }
}