using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New user");
            Console.WriteLine("-------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var passwordHash = Console.ReadLine();
            Console.Write("About you: ");
            var bio = Console.ReadLine();
            Console.Write("Image: ");
            var image = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug,
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Create(user);
                Console.WriteLine("The user has been saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not remove user");
                Console.WriteLine(ex);
            }
        }
    }
}