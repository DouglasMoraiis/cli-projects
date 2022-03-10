using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New role");
            Console.WriteLine("-------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new Role
            {
                Name = name,
                Slug = slug,
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.connection);
                repository.Create(role);
                Console.WriteLine("The role has been saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not remove role");
                Console.WriteLine(ex);
            }
        }
    }
}