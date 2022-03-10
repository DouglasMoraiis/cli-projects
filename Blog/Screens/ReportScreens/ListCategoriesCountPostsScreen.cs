using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListCategoriesCountPostsScreen
    {
        public static void Load()
        {
            Console.WriteLine("List categories / post count");
            Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuReportScreen.Load();
        }

        private static async void List()
        {
            var repository = new Repository<Category>(Database.connection);
            var users = repository.Get();
            foreach (var item in users)
            {
                int countPosts = item.Posts.Count();
                Console.WriteLine($"{item.Name} - Posts: {countPosts}");
            }
        }
    }
}