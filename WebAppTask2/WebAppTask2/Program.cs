using WebAppTask2.Interfaces;
using WebAppTask2.Models;
using WebAppTask2.repositories; 

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

            app.MapGet("/animals/{id}", (IAnimalRepository animalRepository, int id) =>
                animalRepository.Get(id))
                .WithOpenApi();

            // Additional endpoints for visits and other operations
            app.MapGet("/visits/animal/{animalId}", async (IVisitRepository visitRepository, int animalId) =>
                await visitRepository.GetAllForAnimal(animalId))
                .WithOpenApi();

            app.MapPost("/visits", async (IVisitRepository visitRepository, Visit visit) =>
            {
                visitRepository.Add(visit);
                return Results.Created($"/visits/{visit.Id}", visit);
            }).Accepts<Visit>("application/json").WithOpenApi();

            app.MapPut("/visits/{id}", async (IVisitRepository visitRepository, int id, Visit visit) =>
            {
                if (id != visit.Id)
                {
                    return Results.BadRequest("Visit ID mismatch");
                }

                visitRepository.Update(visit);
                return Results.NoContent();
            }).Accepts<Visit>("application/json").WithOpenApi();

            app.MapDelete("/visits/{id}", async (IVisitRepository visitRepository, int id) =>
            {
                visitRepository.Delete(id);
                return Results.NoContent();
            }).WithOpenApi();

            app.Run();
        }
    }
}
