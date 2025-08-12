using System.Net;
using System.Net.Http.Json;
using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;
using Exercicio4.Test.Factory;
using FluentAssertions;

namespace Exercicio4.Test;

public class GradeIntegrationTest : IntegrationTestBase
{
    private readonly HttpClient _httpClient;

    public GradeIntegrationTest(Exercicio4WebApplicationFactory factory) : base(factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Deve_Cadastrar_Grade()
    {
        for (int i = 0; i < 5; i++) await CriarMateriaAsync();

        var grade = new GradeDto() { MateriasId = [1, 2, 3, 4, 5] };

        var response = await _httpClient.PostAsJsonAsync("/api/Grade", grade);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseData = await response.Content.ReadFromJsonAsync<Grade>();
        responseData.Should().NotBeNull();
        responseData.Materias.Count.Should().BeGreaterThanOrEqualTo(5);
        responseData.Id.Should().BeGreaterThan(0);
    }
}