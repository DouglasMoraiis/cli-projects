using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Update category");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Update(new Category
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug,
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Update(category);
                Console.WriteLine("The category has been updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not update category");
                Console.WriteLine(ex);
            }
        }
    }
}