//Service1

using Service1.Service2Services;

namespace Service1; // Note: actual namespace depends on the project name.



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.Configure<ServicesOption>(builder.Configuration.GetSection(ServicesOption.Services));
        builder.Services.AddHttpClient<IService2Service, Service2Service>();
        builder.Services.AddHttpClient<IService3Service, Service3Service>();
        builder.Services.AddScoped<IService2Service, Service2Service>();
        builder.Services.AddScoped<IService3Service, Service3Service>();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}