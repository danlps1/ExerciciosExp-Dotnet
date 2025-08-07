namespace Exercicio4.Domain.Entities;

public class Nota
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public int MateriaId { get; set; }
    public Materia Materia { get; set; }
    public double Valor { get; set; }
}