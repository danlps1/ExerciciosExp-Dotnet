using System.Text.Json.Serialization;
using Exercicio_3.Entities.Enums;

namespace Exercicio_3.Entities;

public class Categoria
{
    public int Id { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))] public CategoriaEnum TipoCategoria { get; set; }

    [JsonIgnore] public ICollection<Veiculo> Veiculos { get; set; }
}