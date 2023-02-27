namespace Lab15_Aksana.Patrubeika_Controllers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Task
            //Разработать Web-приложение предоставляющее следующий функционал
            //1)Вывести информацию с предыдущего задания
            //2)Вывести объект контроллера в формате JSON
            //3)Вывести страницу содержащую переданную в метод параметры(использовать любой
            //из возможных способов передачи параметров на представление)
            //Для реализации приведенного функционала разработать собственный контроллер и представление
            //Для каждого из заданий предусмотреть ссылку на главной странице приложения
            //(по аналогии со ссылками Home, Privacy в дефолтном проекте)
            //Для 3 - го задания разработать в контроллере метод, принимающий минимум
            //3 параметра различных типов
            #endregion

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}