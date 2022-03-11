using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListTagsCountPostsScreen
    {
        public static void Load()
        {
            Console.WriteLine("List tags/post count");
            Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuReportScreen.Load();
        }

        private static async void List()
        {

            var repository = new Repository<Tag>(Database.connection);
            //var tags = repository.GetWithCountPosts();
            foreach (var item in users)
            {
                int countPosts = item.Posts.Count();
                Console.WriteLine($"{item.Name} - Posts: {countPosts}");
            }
        }
    }
}