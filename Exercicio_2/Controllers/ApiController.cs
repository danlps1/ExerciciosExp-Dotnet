using Exercicio_2.Services;
using Exercicio_2.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio_2.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    private readonly IApiService _apiService;

    public ApiController(IApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpPost("marca")]
    public ActionResult<List<ResponseMarcaDto>> CadastrarMarca(MarcaDto marca)
    {
        return Created(string.Empty, _apiService.CadastrarMarca(marca));
    }

    [HttpPost("veiculo")]
    public ActionResult<List<ResponseMarcaDto>> SalvarVeiculo(VeiculoDto veiculo)
    {
        return Created(string.Empty, _apiService.SalvarVeiculo(veiculo));
    }

    [HttpGet("veiculo/{veiculoId}")]
    public ActionResult<ResponseVeiculoDto> BuscarVeiculoPorId(int veiculoId)
    {
        return Ok(_apiService.BuscarVeiculoPorId(veiculoId));
    }

    [HttpPut("veiuclo/{veiculoId}")]
    public ActionResult<ResponseVeiculoDto> EditarVeiculo(int veiculoId, VeiculoDto veiculo)
    {
        return Ok(_apiService.EditarVeiculo(veiculoId, veiculo));
    }

    [HttpDelete("veiculo/{veiculoId}")]
    public ActionResult<ResponseVeiculoDto> DeletarVeiculo(int veiculoId)
    {
        return Ok(_apiService.DeletarVeiculo(veiculoId));
    }
}