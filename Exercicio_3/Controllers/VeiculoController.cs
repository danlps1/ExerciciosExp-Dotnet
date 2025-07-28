using Exercicio_3.Entities;
using Exercicio_3.Services.Dtos;
using Exercicio_3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio_3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeiculoController : ControllerBase
{
    private readonly IVeiculoService _veiculoService;

    public VeiculoController(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }
    
    [HttpPost]
    public async Task<ActionResult<Veiculo>> CadastrarVeiculo(VeiculoDto veiculo)
    {
        return Created(String.Empty, await _veiculoService.CadastrarVeiculo(veiculo));
    }
}