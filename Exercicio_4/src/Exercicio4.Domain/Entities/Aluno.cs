using System.Text.Json.Serialization;

namespace Exercicio4.Domain.Entities;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    [JsonIgnore] public int GradeId { get; set; }
    public Grade Grade { get; set; }
    
    [JsonIgnore] public ICollection<Nota> Notas { get; set; }
}