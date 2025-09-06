using api.Services.IGDB;
using IGDB;
using Microsoft.OpenApi.Models;

namespace api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Read configuration values
        var clientId = builder.Configuration["IGDB:ClientId"];
        var clientSecret = builder.Configuration["IGDB:ClientSecret"];

        // Register IGDBClient as a singleton using configuration values
        builder.Services.AddSingleton<IGDBClient>(_ =>
            IGDBClient.CreateWithDefaults(clientId, clientSecret)
        );

        builder.Services.AddScoped<IGDBGameService>();

        // Configure Swagger/OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API Documentation",
                Version = "v1",
                Description = "This is the API documentation for the application.",
                License = new OpenApiLicense
                {
                    Name = "GNU General Public License version 3",
                    Url = new Uri("https://opensource.org/license/gpl-3-0")
                }
            });

            // Add XML comments if available for better documentation
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                options.RoutePrefix = "api/";
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
