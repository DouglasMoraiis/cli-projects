using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class LinkPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Link post/tag");
            Console.WriteLine("-------------");
            Console.Write("Id post: ");
            var idPost = int.Parse(Console.ReadLine());
            Console.Write("Id tag: ");
            var idTag = int.Parse(Console.ReadLine());
            Link(idPost, idTag);
            Console.ReadKey();
            Load();
        }

        public static void Link(int idPost, int idTag)
        {
            try
            {
                var repository = new PostTagRepository(Database.connection);
                repository.Link(idPost, idTag);
                Console.WriteLine("Post and tag are linked");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not link post with tag.");
                Console.WriteLine(ex);
            }
        }
    }
}