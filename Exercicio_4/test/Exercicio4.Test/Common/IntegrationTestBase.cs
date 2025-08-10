using System.Net.Http.Json;
using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;
using Exercicio4.Test.Factory;

public abstract class IntegrationTestBase : IClassFixture<Exercicio4WebApplicationFactory>
{
    protected readonly HttpClient _httpClient;

    protected IntegrationTestBase(Exercicio4WebApplicationFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    protected async Task<Materia> CriarMateriaAsync(string nome = "Teste")
    {
        var materia = new MateriaDto { Nome = nome };
        var response = await _httpClient.PostAsJsonAsync("/api/Materia", materia);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao criar matéria: {response.StatusCode} - {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<Materia>();
    }

    protected async Task<Grade> CriarGradeAsync()
    {
        var listaMaterias = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            var materia = await CriarMateriaAsync();
            listaMaterias.Add(materia.Id);
        }

        var grade = new GradeDto { MateriasId = listaMaterias };

        var response = await _httpClient.PostAsJsonAsync("/api/Grade", grade);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao criar grade: {response.StatusCode} - {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<Grade>();
    }

    protected async Task<Aluno> CriarAlunoAsync(string nome = "Teste")
    {
        var grade = await CriarGradeAsync();
        var aluno = new AlunoDto { Nome = nome, GradeId = grade.Id };

        var response = await _httpClient.PostAsJsonAsync("/api/Aluno", aluno);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao criar aluno: {response.StatusCode} - {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<Aluno>();
    }
}