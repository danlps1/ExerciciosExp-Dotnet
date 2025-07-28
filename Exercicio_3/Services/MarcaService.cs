using Exercicio_3.Database;
using Exercicio_3.Entities;
using Exercicio_3.Services.Dtos;
using Exercicio_3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_3.Services;

public class MarcaService : IMarcaService
{
    private readonly AppDbContext _context;

    public MarcaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Marca> CadastrarMarca(MarcaDto marcaDto)
    {
        Marca novaMarca = new Marca();

        try
        {
            novaMarca.Nome = marcaDto.Nome;
            _context.Marcas.Add(novaMarca);
            await _context.SaveChangesAsync();

            return novaMarca;
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException($"Erro ao cadastrar marca: {e}");
        }
    }

    public async Task<Marca> BuscarMarcaPordId(int marcaId)
    {
        Marca marca = new Marca();

        try
        {
            var marcaEncontrada = await _context.Marcas.FirstOrDefaultAsync(m => m.Id == marcaId);

            marca = marcaEncontrada ?? throw new ArgumentException("Marca não encontrada");

            return marca;
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException($"Erro ao buscar marca: {e}");
        }
    }
}