using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListPostsWithTagsScreen
    {
        public static void Load()
        {
            Console.WriteLine("List posts (tags,)");
            Console.WriteLine("----------------");
            List();
            Console.ReadKey();
            MenuReportScreen.Load();
        }

        private static async void List()
        {
            var repository = new PostRepository(Database.connection);
            var posts = repository.GetWithTags();
            // foreach (var item in users)
            // {
            //     int countPosts = item.Posts.Count();
            //     Console.WriteLine($"{item.Name} - Posts: {countPosts}");
            // }
        }
    }
}