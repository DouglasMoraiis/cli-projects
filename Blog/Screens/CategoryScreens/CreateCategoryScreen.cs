using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New category");
            Console.WriteLine("-------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var slug = Console.ReadLine();
            Create(new Category
            {
                Name = name,
                Slug = slug,
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Create(category);
                Console.WriteLine("The category has been saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not remove category");
                Console.WriteLine(ex);
            }
        }
    }
}