using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens
{
    public static class ListUserRoleScreen
    {
        public static void Load()
        {
            Console.WriteLine("List user (roles,)");
            Console.WriteLine("-----------------");
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
                string roles = "Role(s): ";
                foreach (var role in item.Roles)
                {
                    if ((item.Roles.Last()).Id != role.Id)
                        roles += role.Name + ",";
                    else
                        roles += role.Name + ".";
                }
                Console.WriteLine($"{item.Name} | {item.Email} | {roles}");
            }
        }
    }
}