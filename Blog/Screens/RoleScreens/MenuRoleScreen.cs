namespace Blog.Screens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Role management");
            Console.WriteLine("-------------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Role list");
            Console.WriteLine("2 - Register role");
            Console.WriteLine("3 - Update role");
            Console.WriteLine("4 - Remove role");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: ListRolesScreen.Load(); break;
                case 2: CreateRoleScreen.Load(); break;
                case 3: UpdateRoleScreen.Load(); break;
                case 4: DeleteRoleScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}