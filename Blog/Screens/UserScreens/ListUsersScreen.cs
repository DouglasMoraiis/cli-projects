using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListUsersScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("User list");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(Database.connection);
            var users = repository.Get();
            foreach (var item in users)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}