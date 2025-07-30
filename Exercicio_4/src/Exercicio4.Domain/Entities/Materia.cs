namespace Exercicio4.Domain.Entities;

public class Materia
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<Grade> Grades { get; set; }
}