using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa; Password=S=jdm123mdj@";

        static void Main(string[] args)
        {
            // CRUD OPERATIONS
            // ReadUsers();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
        }

        public static void ReadUsers()
        {
            var repository = new UserRepository();
            var users = repository.Get();
            
            foreach (var user in users)
            {
                Console.WriteLine("User: " + user.Name);
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine("User: " + user.Name);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Namorada",
                Name = "Samara Jaila",
                Email = "samara@gmail.com",
                Image = "https://samara.com",
                PasswordHash = "HASH",
                Slug = "samara-jaila"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Namorada",
                Name = "Samara Jaila",
                Email = "samara@gmail.com",
                Image = "https://samara.com",
                PasswordHash = "HASH",
                Slug = "samara-jaila"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                Console.WriteLine("Atualização realizada com sucesso!");
            }
        }

        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão realizada com sucesso!");
            }
        }
    }
}