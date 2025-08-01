using System.Text.Json.Serialization;

namespace Exercicio4.Domain.Entities;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int GradeId { get; set; }
    [JsonIgnore] public Grade Grade { get; set; }
}