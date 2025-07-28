using System.ComponentModel.DataAnnotations;

namespace Exercicio_3.Services.Dtos;

public class MarcaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [StringLength(30)]
    public string Nome { get; set; }
}