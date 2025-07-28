using System.ComponentModel.DataAnnotations;

namespace Exercicio_3.Services.Dtos;

public class VeiculoDto
{
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
    [StringLength(30)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo 'Modelo' é obrigatório")]
    public string Modelo { get; set; }

    [Required(ErrorMessage = "O campo 'Cor' é obrigatório")]
    public string Cor { get; set; }

    [Required(ErrorMessage = "O campo 'Ano' é obrigatório")]
    [Range(1, Int32.MaxValue)]
    public int Ano { get; set; }

    [Required(ErrorMessage = "O Id da Marca é obrigatório")]
    [Range(1, Int32.MaxValue)]
    public int MarcaId { get; set; }

    [Required(ErrorMessage = "O campo Id da Categoria é obrigatório")]
    [Range(1, Int32.MaxValue)]
    public int CategoriaId { get; set; }
}