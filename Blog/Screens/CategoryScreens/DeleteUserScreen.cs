using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete category");
            Console.WriteLine("-------------");
            Console.WriteLine("What is the category id?");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("The category has been removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not remove the category");
                Console.WriteLine(ex);
            }
        }
    }
}