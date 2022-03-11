using Blog.Models;
using Blog.Repositories;
using Blog.Screens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost, 1433;Database=Blog;User ID=sa; Password=S=jdm123mdj@; TrustServerCertificate=true";

        static void Main(string[] args)
        {
            Database.connection = new SqlConnection(CONNECTION_STRING);
            Database.connection.Open();
            Load();
            Database.connection.Close();
            Console.ReadKey();
        }

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("MY BLOG");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1 - User Managment");
            Console.WriteLine("2 - Role Managment");
            Console.WriteLine("3 - Category Managment");
            Console.WriteLine("4 - Tag Managment");
            Console.WriteLine("5 - Link Role/User");
            Console.WriteLine("6 - Link Post/Tag");
            Console.WriteLine("7 - Reports");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: MenuUserScreen.Load(); break;
                case 2: MenuRoleScreen.Load(); break;
                case 3: MenuCategoryScreen.Load(); break;
                case 4: MenuTagScreen.Load(); break;
                case 5: LinkUserRoleScreen.Load(); break;
                case 6: break;
                case 7: MenuReportScreen.Load(); break;
                default: Load(); break;
            }
        }

    }
}