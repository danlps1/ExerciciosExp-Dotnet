using System.Text.Json.Serialization;

namespace Exercicio4.Domain.Entities;

public class Materia
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    [JsonIgnore] public ICollection<Grade> Grades { get; set; }
    [JsonIgnore] public ICollection<Nota> Notas { get; set; }
}