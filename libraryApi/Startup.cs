using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using libraryApi.Data;
using libraryApi.Repositories;
using Microsoft.OpenApi.Models;

namespace libraryApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do DbContext para o PostgreSQL com escopo e criação do banco de dados
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                       .EnableSensitiveDataLogging() // Opcional: habilita log de dados sensíveis para facilitar depuração
                       .EnableDetailedErrors()); // Opcional: habilita informações detalhadas de erros para facilitar depuração

            // Registro dos repositórios com escopo
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddControllers();

            // Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Library API",
                    Version = "v1",
                    Description = "API para gerenciar livros e usuários de uma biblioteca",
                    Contact = new OpenApiContact
                    {
                        Name = "Seu Nome",
                        Email = "seu.email@example.com",
                        Url = new System.Uri("https://www.seusite.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença da API",
                        Url = new System.Uri("https://www.seusite.com/licenca")
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Configuração do Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
            });
        }
    }
}
