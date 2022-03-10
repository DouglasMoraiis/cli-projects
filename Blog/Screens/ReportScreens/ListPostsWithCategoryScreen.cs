using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListPostsWithCategoryScreen
    {
        public static void Load()
        {
            Console.WriteLine("List posts (category)");
            Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuReportScreen.Load();
        }

        private static async void List()
        {
            var repository = new Repository<Post>(Database.connection);
            var users = repository.GetWithPosts();
            // foreach (var item in users)
            // {
            //     int countPosts = item.Posts.Count();
            //     Console.WriteLine($"{item.Name} - Posts: {countPosts}");
            // }
        }
    }
}