using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Services;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Diplom_Game.Steam_Aksana.Patrubeika.Migrations;
using Diplom_Game.Steam_Aksana.Patrubeika.Interfaces;

namespace Diplom_Game.Steam_Aksana.Patrubeika
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
           

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            { 
                options.User.RequireUniqueEmail = true; 
            })
             .AddEntityFrameworkStores<ApplicationDbContext>();

            #region Session
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped(sp => SteamCart.GetCart(sp));
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

            #endregion

            builder.Services.AddControllersWithViews();
            //builder.Services.AddMemoryCache();
            //builder.Services.AddSession();

            var app = builder.Build();

            //app.Run(async (context) =>
            //{
            //    var response = context.Response;
            //    var request = context.Request;

            //    response.ContentType = "text/html; charset=utf-8";

            //    if (request.Path == "/wwwroot/img" && request.Method == "POST")
            //    {
            //        IFormFileCollection files = request.Form.Files;
            //        // путь к папке, где будут храниться файлы
            //        var uploadPath = $"{Directory.GetCurrentDirectory()}/wwwroot/img";
            //        // создаем папку для хранения файлов
            //        Directory.CreateDirectory(uploadPath);

            //        foreach (var file in files)
            //        {
            //            // путь к папке uploads
            //            string fullPath = $"{uploadPath}/{file.FileName}";

            //            // сохраняем файл в папку uploads
            //            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            //            {
            //                await file.CopyToAsync(fileStream);
            //            }
            //        }
            //        await response.WriteAsync("Файлы успешно загружены");
            //    }
            //    else
            //    {
            //        await response.SendFileAsync("html/index.html");
            //    }
            //});

            app.UseSession();   // добавляем middleware для работы с сессиями

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapRazorPages();

            app.Run();
        }
    }
}