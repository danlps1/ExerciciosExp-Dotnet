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
    public ActionResult<List<MarcaDto>> CadastrarMarca(MarcaDto marca)
    {
        return Created(string.Empty, _apiService.CadastrarMarca(marca));
    }
}