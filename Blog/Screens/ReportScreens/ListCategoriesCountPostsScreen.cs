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
            var repository = new CategoryRepository(Database.connection);
            var users = repository.GetWithPosts();
            foreach (var item in users)
            {
                int countPosts = item.Posts.Count();
                Console.WriteLine($"{item.Name} - Posts: {countPosts}");
            }
        }
    }
}