using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class LinkUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Link user/role");
            Console.WriteLine("-------------");
            Console.Write("Id user: ");
            var idUser = int.Parse(Console.ReadLine());
            Console.Write("Id role: ");
            var idRole = int.Parse(Console.ReadLine());
            Link(idUser, idRole);
            Console.ReadKey();
            Load();
        }

        public static void Link(int idUser, int idRole)
        {
            try
            {
                var repository = new UserRoleRepository(Database.connection);
                repository.Link(idUser, idRole);
                Console.WriteLine("User and Role are linked");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not link user with role.");
                Console.WriteLine(ex);
            }
        }
    }
}