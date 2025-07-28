namespace Exercicio_3.Entities;

public class Veiculo
{
    public int Id { get; set; }
    
    public string Nome { get; set; } = string.Empty;
    
    public string Modelo { get; set; } = string.Empty;
    
    public string Cor { get; set; } = string.Empty;
    
    public int Ano { get; set; }
    
    public int MarcaId { get; set; }
    public Marca Marca { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

  
}