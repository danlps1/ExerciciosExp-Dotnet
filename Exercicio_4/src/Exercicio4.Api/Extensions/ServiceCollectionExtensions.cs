using Exercicio4.Application.Interfaces;
using Exercicio4.Application.Services;
using Exercicio4.Infrastructure.Repositories;   
using Exercicio4.Infrastructure.Repositories.Interfaces;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMateriaRepository, MateriaRepository>();
        services.AddScoped<IAlunoRepository, AlunoRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMateriaService, MateriaService>();
        services.AddScoped<IAlunoService, AlunoService>();
        services.AddScoped<IGradeService, GradeService>();
        return services;
    }
}