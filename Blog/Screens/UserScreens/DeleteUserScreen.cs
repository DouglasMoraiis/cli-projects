using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete user");
            Console.WriteLine("-------------");
            Console.WriteLine("What is the user id?");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("The user has been removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not remove the user");
                Console.WriteLine(ex);
            }
        }
    }
}