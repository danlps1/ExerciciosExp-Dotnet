namespace Exercicio4.Domain.Entities;

public class Grade
{
    public int Id { get; set; }
    public ICollection<Aluno> Alunos { get; set; }
    public ICollection<Materia> Materias { get; set; }
}