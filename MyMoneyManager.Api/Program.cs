using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Services;
using MyMoneyManager.Api.Storage;

namespace MyMoneyManager.Api;

/// <summary>
/// Main application class
/// </summary>
public class Program
{
    /// <summary>
    /// Application entrypoint
    /// </summary>
    public static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date",
                Example = new OpenApiString("2022-01-01")
            });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My Money Manager API",
                Version = "v1",
                Description = "An API for a money management app",
                // TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Andrii Lytvyn",
                    Email = "lytvyn.andrii.contact@gmail.com",
                    Url = new Uri("https://tappitikarrass.github.io/"),
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT"),
                }
            });
            // Set the comments path for the Swagger JSON and UI.
            String xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            String xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<INotebookService, NotebookService>();
        builder.Services.AddSingleton<IOperationService, OperationService>();

        builder.Services.AddSingleton<IUserStorage, SqliteUserStorage>();
        builder.Services.AddSingleton<INotebookStorage, SqliteNotebookStorage>();
        builder.Services.AddSingleton<IOperationStorage, SqliteOperationStorage>();

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=./app.db"));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(options =>
                    {
                        options.RouteTemplate = "{documentname}/swagger.json";
                    }
                    );
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "";
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
