using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost, 1433;Database=Blog;User ID=sa; Password=S=jdm123mdj@; TrustServerCertificate=true";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            DeleteUser(connection);
            ReadUsersWithRoles(connection);
            ReadRoles(connection);


            connection.Close();
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
                foreach (var role in item.Roles) 
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }

        }
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = new User()
            {
                Name = "Jander",
                Bio = "Lindo",
                Email = "jander@fitbank",
                Image = "http://img.com",
                PasswordHash = "password",
                Slug = "jander-morais",
            };
            repository.Create(user);
            Console.WriteLine("Usuário criado!");

        }
        public static void CreateTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var user = new Tag()
            {
                Name = "Jander",
                Slug = "jander-morais",
            };
            repository.Create(user);
            Console.WriteLine("Tag criado!");
        }
        public static void CreateRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = new Role()
            {
                Name = "Jander",
                Slug = "jander-morais",
            };
            repository.Create(role);
            Console.WriteLine("Role criado!");
        }

        public static void ReadUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(1);
            Console.WriteLine($"{user.Id} - {user.Name}");
        }
        public static void ReadTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tag = repository.Get(1);
            Console.WriteLine($"{tag.Id} - {tag.Name}");
        }
        public static void ReadRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Get(1);
            Console.WriteLine($"{role.Id} - {role.Name}");
        }


        public static void UpdateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = new User()
            {
                Id = 2,
                Name = "Douglsdaas",
                Bio = "Gostoso",
                Email = "jander@fitbank",
                Image = "http://img.com",
                PasswordHash = "password",
                Slug = "jander-morais213",
            };
            repository.Update(user);
        }
        public static void DeleteUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            repository.Delete(2);
        }
    }
}