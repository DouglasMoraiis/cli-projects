using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListUserRoleScreen
    {
        public static void Load()
        {
            Console.WriteLine("List user/role");
            Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuReportScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.connection);
            var users = repository.GetWithRoles();
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Name} ({item.Slug})");
                string roles = "role(s): ";
                foreach (var role in item.Roles)
                {
                    roles += role.Name + ",";
                }
                Console.WriteLine(roles);
            }
        }
    }
}