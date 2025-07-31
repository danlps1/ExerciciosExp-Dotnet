using System.ComponentModel.DataAnnotations;

namespace Exercicio4.Application.Dtos;

public class MateriaDto
{
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(30)]
    public string Nome { get; set; }
}