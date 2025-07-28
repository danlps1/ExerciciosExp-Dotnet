using Exercicio_3.Entities;
using Exercicio_3.Services.Dtos;

namespace Exercicio_3.Services.Interfaces;

public interface IMarcaService
{
    public Task<Marca> CadastrarMarca(MarcaDto marca);
    public Task<Marca> BuscarMarcaPordId(int marcaId);
}