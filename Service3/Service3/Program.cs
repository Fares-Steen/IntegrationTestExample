//Service3

using ApplicationDI;
using S2.PersistenceDI;
using S2.SQL.Persistence.Initialize;


namespace Service1; // Note: actual namespace depends on the project name.



internal class Program
{
    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddPersistenceDbContext(connectionString);
        builder.Services.AddPersistenceLibrary();
        builder.Services.AddApplicationLibrary();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        builder.Services.BuildServiceProvider().GetService<IDbInitializer>()?.Initialize();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}