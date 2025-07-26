namespace Exercicio_1.Services;

public interface IApiService
{
    // Versão 1
    public int Somar10(int numero);
    public string Concatenar(string palavra);
    
    // Versão 2
    public int SomarValor(int numero);
    public List<string> AddNome(string nome);
    
    // Versão 3
    public void ExcluirNome(string nome);
}