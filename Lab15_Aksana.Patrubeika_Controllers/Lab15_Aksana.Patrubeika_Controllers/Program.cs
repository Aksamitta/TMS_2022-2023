namespace Lab15_Aksana.Patrubeika_Controllers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Task
            //����������� Web-���������� ��������������� ��������� ����������
            //1)������� ���������� � ����������� �������
            //2)������� ������ ����������� � ������� JSON
            //3)������� �������� ���������� ���������� � ����� ���������(������������ �����
            //�� ��������� �������� �������� ���������� �� �������������)
            //��� ���������� ������������ ����������� ����������� ����������� ���������� � �������������
            //��� ������� �� ������� ������������� ������ �� ������� �������� ����������
            //(�� �������� �� �������� Home, Privacy � ��������� �������)
            //��� 3 - �� ������� ����������� � ����������� �����, ����������� �������
            //3 ��������� ��������� �����
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