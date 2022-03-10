using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete role");
            Console.WriteLine("-------------");
            Console.WriteLine("What is the role id?");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("The role has been removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not remove the role");
                Console.WriteLine(ex);
            }
        }
    }
}