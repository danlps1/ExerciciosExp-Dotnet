using System.ComponentModel.DataAnnotations;

namespace Exercicio4.Application.Dtos;

public class AlunoDto
{
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório")]
    [Range(1, Int32.MaxValue)]
    public int GradeId { get; set; }
}