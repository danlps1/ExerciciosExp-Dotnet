namespace Exercicio_3.Entities;

public class Marca
{
    public int Id { get; set; }
    
    public string Nome { get; set; } = string.Empty;

    public ICollection<Veiculo> Veiculos { get; set; }
}