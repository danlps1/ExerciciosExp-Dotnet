namespace Exercicio_1.Services;

public class ApiService : IApiService
{
    private int _numeroArmazenado;
    List<string> list = new List<string>();

    // Versão1
    public int Somar10(int numero)
    {
        _numeroArmazenado = numero;
        return _numeroArmazenado + 10;
    }

    public string Concatenar(string palavra) => $"Daniel{palavra}";

    // Versão 2
    public int SomarValor(int numero) => _numeroArmazenado += numero;

    public List<string> AddNome(string nome)
    {
        list.Add(nome);
        return list;
    }

    // Versão 3
    public void ExcluirNome(string nome)
    {
        list.Remove(nome);
        Console.WriteLine($"Nome removido: {nome}");
    }
}