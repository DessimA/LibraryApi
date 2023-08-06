using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using libraryApi.Data;
using System;

namespace libraryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<LibraryDbContext>();
                    // Aplicar migrações pendentes e criar o banco de dados se necessário
                    dbContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    // Tratar erros relacionados à criação do banco de dados ou migrações
                    // Aqui você pode adicionar tratamento de erros apropriado, se necessário.
                    Console.WriteLine($"Erro na criação do banco de dados: {ex.Message}");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
