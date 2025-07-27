using System.Text.Json.Serialization;

namespace Exercicio_2.Services.Dto;

public class ResponseMarcaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
}