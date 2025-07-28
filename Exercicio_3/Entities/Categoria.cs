using Exercicio_3.Entities.Enums;

namespace Exercicio_3.Entities;

public class Categoria
{
    public int Id { get; set; }

    public CategoriaEnum TipoCategoria { get; set; }

    public ICollection<Veiculo> Veiculos { get; set; }
}