using DotNetEnv; // Biblioteca para carregar variáveis de ambiente a partir do arquivo .env
using libraryApi.Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using libraryApi.Repositories;

Env.Load(); // Carrega as variáveis de ambiente do arquivo .env

var builder = WebApplication.CreateBuilder(args);

// Configuração do ambiente
if (builder.Environment.IsDevelopment())
{
    builder.Logging.ClearProviders(); // Limpa os provedores de log existentes
    builder.Logging.AddConsole(); // Adiciona o provedor de log de console
}

ConfigureServices(builder); // Configuração dos serviços (injeção de dependência)
ConfigureDatabase(builder); // Configuração do banco de dados
ConfigureSwagger(builder); // Configuração do Swagger

var app = builder.Build();

app.UseRouting();
app.UseSwagger(); // Habilita o uso do Swagger para documentar a API
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Mapeia os endpoints dos controladores
});

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers(); // Adiciona suporte a controladores
    builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte a exploração de API
    builder.Services.AddScoped<ILivroRepository, LivroRepository>();
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
}

void ConfigureDatabase(WebApplicationBuilder builder)
{
    var dbConnectionString = Env.GetString("DATABASE_CONNECTION_STRING"); // Lê a string de conexão do arquivo .env
    builder.Services.AddDbContext<LibraryDbContext>(options =>
    {
        options.UseNpgsql(dbConnectionString); // Configura o uso do PostgreSQL com a string de conexão lida
    });
}

void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Library API",
            Version = "v1",
            Description = "API para gerenciar livros e usuários de uma biblioteca"
        });
    });
}
