using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListCategorysScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Category list");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Category>(Database.connection);
            var categories = repository.Get();
            foreach (var item in categories)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}