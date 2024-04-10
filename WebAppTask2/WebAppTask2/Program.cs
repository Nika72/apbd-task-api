using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppTask2.Interfaces;
using WebAppTask2.repositories; // Adjust the namespace according to your project structure

namespace WebAppTask2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            // Add your custom services
            builder.Services.AddSingleton<IAnimalRepository, AnimalRepository>();
            builder.Services.AddSingleton<IVisitRepository, VisitRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            // Map controllers
            app.MapControllers();

            // Additional endpoints for animals
            app.MapGet("/animals", async (IAnimalRepository animalRepository) =>
                    await animalRepository.GetAll())
                .WithOpenApi();

            app.MapGet("/animals/{id}", (IAnimalRepository animalRepository, int id) => animalRepository.Get(id))
                .WithOpenApi();

            // Additional endpoints for visits and other operations

            app.Run();
        }
    }
}