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

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("MEU BLOG");
            Console.WriteLine();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuário");
            Console.WriteLine("2 - Gestão de Perfil");
            Console.WriteLine("3 - Gestão de Categoria");
            Console.WriteLine("4 - Gestão de Tag");
            Console.WriteLine("5 - Vincular Perfil/Usuário");
            Console.WriteLine("6 - Vincular Post/Tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: MenuUserScreen.Load(); break;
                case 2: MenuRoleScreen.Load(); break;
                //case 3: MenuCategoryScreen.Load(); break;
                case 4: MenuTagScreen.Load(); break;
                case 5: ListUserRoleScreen.Load(); break;
                default: Load(); break;
            }
        }

    }
}