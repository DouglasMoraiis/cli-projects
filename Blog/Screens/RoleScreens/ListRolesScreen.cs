using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListRolesScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Role list");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Role>(Database.connection);
            var roles = repository.Get();
            foreach (var item in roles)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}