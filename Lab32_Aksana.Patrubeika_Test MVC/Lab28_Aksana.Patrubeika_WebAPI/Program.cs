using Lab28_Aksana.Patrubeika_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;

namespace Lab28_Aksana.Patrubeika_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibrariesDb"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                options =>
                {
                    var basePath = AppContext.BaseDirectory;
                    var xmlPath = Path.Combine(basePath, "Lab28_Aksana.Patrubeika_WebAPI.xml");
                    options.IncludeXmlComments(xmlPath);
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Books library",
                        Contact = new OpenApiContact
                        {
                            Name = "Aksana Patrubeika",
                            Url = new Uri("https://github.com/Aksamitta")
                        },
                    });
                });

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
}