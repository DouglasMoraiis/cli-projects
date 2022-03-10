using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Qual o id da tag?");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("A tag foi excluida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a tag");
                Console.WriteLine(ex);
            }
        }
    }
}