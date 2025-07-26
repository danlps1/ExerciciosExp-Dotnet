using Exercicio_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio_1.Controllers;

[Route(("[controller]"))]
[ApiController]
public class ApiController : ControllerBase
{
    private readonly IApiService _apiService;

    public ApiController(IApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet("somar10/{numero}")]
    public ActionResult<int> Somar10(int numero)
    {
        return Ok(_apiService.Somar10(numero));
    }

    [HttpGet("concatenar")]
    public ActionResult<string> Concatenar([FromQuery] string palavra)
    {
        return Ok(_apiService.Concatenar(palavra));
    }

    [HttpPut("somarValor/{numero}")]
    public ActionResult<int> SomarValor(int numero)
    {
        return Ok(_apiService.SomarValor(numero));
    }

    [HttpPost("adicionarNome")]
    public ActionResult<List<string>> AddNome([FromBody] string nome)
    {
        return Created(string.Empty, _apiService.AddNome(nome));
    }

    [HttpDelete("excluirNome")]
    public ActionResult ExcluirNome([FromBody] string nome)
    {
        _apiService.ExcluirNome(nome);
        return NoContent();
    }
}