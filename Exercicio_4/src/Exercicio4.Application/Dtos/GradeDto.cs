using System.ComponentModel.DataAnnotations;

namespace Exercicio4.Application.Dtos;

public class GradeDto
{
    [Required(ErrorMessage = "O campo é obrigatório")]
    public List<int> MateriasId { get; set; }
}